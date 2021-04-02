using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENPCharacter : Character
{
    //사용클래스
    [SerializeField] ENPCBehaviorTree enemy_AI;
    [SerializeField] Gun defultGun;
    Gun currentGun;

    #region Properties
    public ENPCBehaviorTree Enemy_AI { get { return enemy_AI; } set { enemy_AI = value; } }
    public Gun CurrentGun { get { return currentGun; } set { } }
    #endregion


    override protected void Awake()
    {
        base.Awake();

        CurrentState = IdleState;
        IsIdle = true;


    }
    private void Start()
    {
        characterObjectManager = GameObject.Find("CharacterObjectManager").GetComponent<CharacterObjectManager>();

        characterObjectManager.AddObjectList(this);

        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();

        //캐릭터 기본 애니메이션 (Idle)
        if(IdleState.AnimatorController_CharacterState!=null)
        {
            MyAnimator.runtimeAnimatorController = IdleState.AnimatorController_CharacterState;
        }
        prevMoveDirection_X = 1;
        //시작 무기(초기)
        currentGun = defultGun;
    }

    private void FixedUpdate()
    {
        CurrentState.Execution();
    }

    private void Update()
    {
        enemy_AI.ControlCommand();
        CurrentState.Animation();
    }
}
