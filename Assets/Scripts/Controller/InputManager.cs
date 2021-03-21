using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //1.플레이어의 입력을 받는다.
    //2.입력을 받고 캐릭터의 상태 판단 bool 값을 전환해준다.
    //3.이 스크립트에서 조건을 걸지 않도록 한다.
    //4.BehaviorTree 기반 스크립트에서 조건을 제시하고 판단한다.
    //5.BehaviorTree의 Action 스크립트에서 상태 전환을 실시한다.
    //6.각 상태에서 해당 상태에서 해야될 행동을 처리한다.
    //7.행동 처리 후 일정 시간(Time.deltatime)이 지난 다음 기본 상태(IDLE,REDY_TO_ATTACK)


    //키코드 분류용 keyName
    //Dictionary 사용

    enum keyName
    {
        Dodge = 0,
        Guard = 1,
        Direction = 2,
        Attack = 3,
        SkillUse_1 = 4,
        SkillUse_2 = 5,
        SkillUse_3 = 6,
        SkillUse_4 = 7,
        SelectCharacter_1 = 8,
        SelectCharacter_2 = 9,
        SelectCharacter_3 = 10,
        SelectCharacter_4 = 11,
        TimeReset = 12
    }

    [SerializeField] PCharacter character; // Input Manager을 사용할 캐릭터 스크립트에서 이 변수를 변경해준다. 이후 수정 필요할듯.


    Dictionary<KeyCode, keyName> keyDictionary;

    protected List<KeyCode> activeInputs = new List<KeyCode>();


    //방향 입력 변수
    float horizontal;
    float vertical;
    float preHorizontal;

    //버튼 Up 감지용 변수
    //bool isPress;

    //마우스 입력 방향 계산용
    Camera myCamera;
    Vector3 mousePosition;

    TimeManager timeManager;




    private void Start()
    {
        //Dictionary 이용한 입력 키 감지
        keyDictionary = new Dictionary<KeyCode, keyName>
            {
                {KeyCode.A, keyName.Direction},
                {KeyCode.D, keyName.Direction},
                {KeyCode.W, keyName.Direction},
                {KeyCode.S, keyName.Direction},
                {KeyCode.Space, keyName.Dodge},
                {KeyCode.Mouse0, keyName.Attack},
                {KeyCode.Z, keyName.SkillUse_1},
                {KeyCode.X, keyName.SkillUse_2},
                {KeyCode.C, keyName.SkillUse_3},
                {KeyCode.V, keyName.SkillUse_4},
                {KeyCode.R, keyName.TimeReset}
            };
        myCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        horizontal = 1;

    }

    public void InputCommand()
    {
        List<KeyCode> pressedInput = new List<KeyCode>();

        List<KeyCode> releasedInput = new List<KeyCode>();


        if (Input.anyKey || Input.anyKeyDown)
        {
            //입력 감지
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    ButtonActionDown(dic.Value);
                    //Debug.Log(dic.Key + " 키 눌렀다");
                }
                if (Input.GetKey(dic.Key))
                {
                    activeInputs.Remove(dic.Key); // 중복 입력 방지
                    activeInputs.Add(dic.Key); // 활성화 된 키 추가, 액티브에는 하나의 키는 하나만 존재
                    pressedInput.Add(dic.Key); // 이번 업데이트에 눌렸던  모든 키

                    //Debug.Log(dic.Key + " 키 누르는 중");

                    ButtonAction(dic.Value);

                }
            }
        }

        foreach (var code in activeInputs)
        {
            releasedInput.Add(code); // 활성화 된 모든 키 추가

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " 키 풀림.");

                ButtonActionUp(keyDictionary[code]);
            }

        }

        activeInputs = releasedInput;
    }

    void ButtonAction(keyName name)
    {
        switch (name)
        {
            //시간 역재생
            case keyName.TimeReset: //test
                ButtonEvent_TimeRest_Start();
                break;

            //이동
            //누르는 동안 해당 방향으로 이동
            //대기 상태를 취소한다.
            case keyName.Direction:
                //Invoke("ButtonEvent_Direction_Start", 0.1f);
                ButtonEvent_Direction_Start();
                break;


            //스킬 사용
            //누르는 동안 스킬 사용 시도한다.
            //대기 상태를 취소한다.
            //쿨타임중에는 스킬을 사용을 해도 사용되지 않아야한다.
            case keyName.SkillUse_1:
                ButtonEvent_SkillUse_1();
                break;
            case keyName.SkillUse_2:
                ButtonEvent_SkillUse_2();
                break;
            case keyName.SkillUse_3:
                ButtonEvent_SkillUse_3();
                break;
            case keyName.SkillUse_4:
                ButtonEvent_SkillUse_4();
                break;
        }
    }

    void ButtonActionDown(keyName name)
    {
        switch (name)
        {
            //회피
            //공격 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
            //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
            //누르면 1회 회피한다.
            //대기 상태를 취소한다.
            //가드를 취소한다.
            //이동을 취소한다.
            case keyName.Dodge:
                ButtonEvent_Dodge();
                //Debug.Log("회피 실행");
                break;

            //공격
            //회피 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
            //+회피 입력 도중 입력시 회피 이후 공격(다른 액션)을 한다.(추가구현 필요)
            //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
            //누르면 1회 공격
            //대기 상태를 취소한다.
            //가드를 취소한다.
            //이동을 취소한다.
            case keyName.Attack:
                ButtonEvent_Attack();
                break;

        }
    }

    void ButtonActionUp(keyName name)
    {
        switch (name)
        {
            //시간 역재생
            case keyName.TimeReset: //test
                ButtonEvent_TimeRest_End();
                break;
            //이동
            //이동을 종료한다.
            //대기 상태를 취소한다.
            case keyName.Direction:
                Invoke("ButtonEvent_Direction_End", 0.1f);
                //ButtonEvent_Direction_End();
                break;
        }
    }

    
    //test
    void ButtonEvent_TimeRest_Start()
    {
        if(timeManager.isTimeSaved)
        timeManager.SetIsTimeReset(true);
    }
    void ButtonEvent_TimeRest_End()
    {
        timeManager.SetIsTimeReset(false);
    }

    //

    void ButtonEvent_Direction_Start()
    {
        //이동
        //누르는 동안 해당 방향으로 이동
        //대기 상태를 취소한다.

        //if (!characterManager.Character.IsAttack)
        //{

        if(!((timeManager.isTimeReset) || (character.IsDodge)))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            character.Move_Direction = new Vector3(horizontal, vertical, 0).normalized;

        }




        //양방향 입력으로 인한 방향값 (0,0) 에 대한 예외처리 나중에 다시 손볼 것
        //if(characterManager.Character.Move_Direction.x==0 && characterManager.Character.Move_Direction.y == 0)
        //{
        //    characterManager.Character.IsIdle = true;
        //    return;
        //}


        character.IsIdle = false;
        character.IsMove = true;

        //Debug.Log("이동 버튼 눌리는중");
        //}
    }

    void ButtonEvent_Direction_End()
    {
        character.Move_Direction = new Vector3(horizontal, vertical, 0).normalized;

        character.IsIdle = true;
        character.IsMove = false;

        //Debug.Log("이동 버튼 뗏다.");
    }
    void ButtonEvent_Dodge()
    {
        //회피
        //공격 도중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
        //스킬 사용중에는 사용할 수 없다. (Tree에서 Dec으로 처리)
        //누르면 1회 회피한다.
        //대기 상태를 취소한다.
        //가드를 취소한다.
        //이동을 취소한다.
        character.IsDodge = true;
        character.IsMove = false;
        character.IsIdle = false;
        //test
        Debug.Log("Dodge");
    }
    void ButtonEvent_Attack()
    {
        //공격은 클락옆의 부유체가 한다.
        //클락의 행동에 아무런 영향도 끼치지 않는다.

        //마우스 공격 방향 입력
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        character.CurrentGun.AttackDirection = mousePosition - character.CurrentGun.transform.position;
        character.CurrentGun.AttackDirection = character.CurrentGun.AttackDirection.normalized;

        character.CurrentGun.isAttack = true;

        //Debug.Log("공격 방향" + character.Attack_Direction);
    }
    void ButtonEvent_SkillUse_1()
    {
        character.IsSkilluse_1 = true;
    }
    void ButtonEvent_SkillUse_2()
    {
        character.IsSkilluse_2 = true;

    }
    void ButtonEvent_SkillUse_3()
    {
        character.IsSkilluse_3 = true;
    }
    void ButtonEvent_SkillUse_4()
    {
        character.IsSkilluse_4 = true;
    }
    void ButtonEvent_SelectCharacter_1()
    {

    }
    void ButtonEvent_SelectCharacter_2()
    {
    }
    void ButtonEvent_SelectCharacter_3()
    {
    }
    void ButtonEvent_SelectCharacter_4()
    {
    }


    public virtual float SetParameter(Vector2 direction)
    {
        float posX = 0.5f;
        float posY = 0.866f;

        //Debug.Log(direction);


        if (direction.x > -posX && direction.x < posX && direction.y < -posY && direction.y > -1) // Down
        {
            //Debug.Log("Down" + direction);
            return 1;
        }
        if (direction.x <= -posX && direction.x >= -1 && direction.y <= 0 && direction.y >= -posY) // Left Dwon
        {
            //Debug.Log("Left Dwon" + direction);
            return 2;
        }
        if (direction.x > -1 && direction.x <= -posX && direction.y > 0 && direction.y <= posY) // Left Up
        {
            //Debug.Log("Left Up" + direction);
            return 3;
        }
        if (direction.x <= 1 && direction.x >= posX && direction.y >= -posY && direction.y <= 0) // Right Down
        {
            //Debug.Log("Right Down" + direction);
            return 4;
        }
        if (direction.x >= posX && direction.x < 1 && direction.y <= posY && direction.y > 0) // Right Up
        {
            //Debug.Log("Right Up" + direction);
            return 5;
        }
        if (direction.x > -posX && direction.x < posX && direction.y > posY && direction.y < 1) // Up
        {
            //Debug.Log("Up" + direction);
            return 6;
        }
        return 0;
    }

}



