using UnityEngine;

public class Character : InteractableObject
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;


    //이동 방향
    private Vector3 move_Direction;
    private Vector3 attack_Direction;
    protected float prevMoveDirection_X;

    //출력 애니메이션 클립 번호
    public float AnimationNumber;

    //공격 대상
    [SerializeField] LayerMask enemy_LayerMask;

    //캐릭터 리스트 관리 매니저
    protected CharacterObjectManager characterObjectManager;

    #region Character Stat Variables

    //SerailizeField로 한 것들은 인스펙터에서 디자인할 수 있도록 함

    ///캐릭터 프로필
    [SerializeField] private string character_Name; //캐릭터 이름

    ///경험치
    [SerializeField] private float current_Character_Experience; //현재 캐릭터 경험치 테이블
    private float now_Character_Experience; //현재 경험치

    ///스탯 경험치 
    [SerializeField] private float current_Vigor_Experience; //현재 체력 경험치 테이블
    private float now_Vigor_Experience; //현재 체력 경험치
    [SerializeField] private float current_Endurance_Experience; //현재 지구력 경험치 테이블
    private float now_Endurance_Experience; //현재 지구력 경험치
    [SerializeField] private float current_Attunement_Experience; //현재 집중력 경험치 테이블
    private float now_Attunement_Experience; //현재 집중력 경험치
    [SerializeField] private float current_Strength_Experience; //현재 힘 경험치 테이블
    private float now_Strength_Experience; //현재 힘 경험치
    [SerializeField] private float current_Intelligence_Experience; //현재 지력 경험치 테이블
    private float now_Intelligence_Experience; //현재 지력 경험치
    [SerializeField] private float current_Dexterity_Experience; //현재 기량 경험치 테이블
    private float now_Dexterity_Experience; //현재 기량 경험치
    [SerializeField] private float current_Luck_Experience; //현재 운 경험치 테이블
    private float now_Luck_Experience; //현재 운 경험치
    [SerializeField] private float current_Charisma_Experience; //현재 매력 경험치 테이블
    private float now_Charisma_Experience; //현재 매력 경험치

    ///플레이어가 선택할 수 있는 스탯(직접 수정 가능)

    [SerializeField] private float defult_Vigor; //체력
    private float now_Vigor;
    [SerializeField] private float defult_Endurance; //지구력
    private float now_Endurance;
    [SerializeField] private float defult_Attunement; //집중력
    private float now_Attunement;
    [SerializeField] private float defult_Strength; //힘
    private float now_Strength;
    [SerializeField] private float defult_Intelligence; //지력
    private float now_Intelligence;
    [SerializeField] private float defult_Dexterity; //기량
    private float now_Dexterity;
    [SerializeField] private float defult_Luck; //운
    private float now_Luck;
    [SerializeField] private float defult_Charisma; //매력
    private float now_Charisma;

    ///자원 스탯
    ///선택 스탯에 영향을 받음(간접적으로 수정 가능)
    [SerializeField] private float max_Health_Point; //기본 HP(생명력)
    private float now_Health_Point;
    [SerializeField] private float max_Stamina_Point; //기본 SP(지구력)
    private float now_Stamina_Point;
    [SerializeField] private float max_Mind_Point; //기본 MP(정신력)
    private float now_Mind_Point;
    [SerializeField] private float max_Equip_Load; //최대 장비 부하
    private float now_Equip_Load;

    ///행동에 영향을 주는 스탯
    ///선택 스탯에 영향을 받음(간접적으로 수정 가능)
    [SerializeField] private float defult_Move_Speed; //기본 이동속도
    private float now_Move_Speed;
    [SerializeField] private float defult_Physical_Attack_Power; //기본 물리 공격력
    private float now_Physical_Attack_Power;
    [SerializeField] private float defult_Magic_Attack_Power; //기본 마법 공격력
    private float now_Magic_Attack_Power;
    [SerializeField] private float defult_Physical_Defense_Power; //기본 물리 방어력
    private float now_Physical_Defense_Power;
    [SerializeField] private float defult_Magic_Defense_Power; //기본 마법 방어력
    private float now_Magic_Defense_Power;
    [SerializeField] private float defult_Critical_Rate; //기본 크리티컬 확률
    private float now_Critical_Rate;
    [SerializeField] private float defult_Critical_Attack_Resistance; //기본 크리티컬 저항력
    private float now_Critical_Attack_Resistance;
    [SerializeField] private float defult_Block; //기본 가드율
    private float now_Block;
    [SerializeField] private float defult_Attack_Width_Range; //기본 공격범위(폭)
    private float now_Attack_Width_Range;
    [SerializeField] private float defult_Attack_Length_Range; //기본 공격범위(길이)
    private float now_Attack_Length_Range;
    [SerializeField] private float defult_Sight; //기본 시야(캐릭터가 볼 수 있는 거리)
    private float now_Sight;

    #endregion

    #region States

    [SerializeField] private State currentState;

    private State_Attack attackState;
    private State_Death deathState;
    private State_Dodge dodgeState;
    private State_Guard guardState;
    private State_Hit hitState;
    private State_Idle idleState;
    private State_Move moveState;
    private State_Battle_Idle battle_idleState;
    private State_SkillUse skillUseState;
    private State_TargetSearch targetSearchState;


    #endregion

    #region Status enabled or not
    private bool isAttack;
    private bool isDodge;
    private bool isGuard;
    private bool isIdle;
    private bool isInput;
    private bool isMove;
    private bool isBattle_Idle;
    private bool isSkilluse_1;
    private bool isSkilluse_2;
    private bool isSkilluse_3;
    private bool isSkilluse_4;

    //isHit 는 상위 클래스에서 선언
    //isDeath 는 상위 클래스에서 선언



    #endregion

    #region Equip

    //Weapon
    protected Weapon right_Hand;
    protected Weapon left_Hand;

    //Armor
    protected Armor armor;

    #endregion

    #region Properties

    //물리
    ///읽기 전용
    public Rigidbody2D MyRigidbody { get { return myRigidbody; } }

    //애니메이션
    public Animator MyAnimator { get { return myAnimator; } set { myAnimator = value; } }


    //캐릭터 이름


    //캐릭터 경험치


    //캐릭터 스탯 경험치


    //캐릭터 선택 스탯


    //캐릭터 자원 스탯


    //캐릭터 행동 스탯
    public  float Now_Attack_Width_Range { get { return now_Attack_Width_Range; } protected set { now_Attack_Width_Range = value; } }
    public float Now_Attack_Length_Range { get { return now_Attack_Length_Range; } protected set { now_Attack_Length_Range = value; } }

    //파생 클래스에서만 쓰기 가능
    public float Now_HP { get { return now_Health_Point; } protected set { now_Health_Point = value; } }
    public float Defult_Move_Speed { get { return defult_Move_Speed; } set { defult_Move_Speed = value; } }
    public float Now_Speed { get { return now_Move_Speed; } set { now_Move_Speed = value; } }
    public float Now_Physical_Attack_Power { get { return now_Physical_Attack_Power; } protected set { now_Physical_Attack_Power = value; } }
    public float Now_Defense_Power { get { return now_Physical_Defense_Power; } protected set { now_Physical_Defense_Power = value; } }

    public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
    public bool IsDodge { get { return isDodge; } set { isDodge = value; } }
    public bool IsGuard { get { return isGuard; } set { isGuard = value; } }
    public bool IsIdle { get { return isIdle; } set { isIdle = value; } }
    public bool IsInput { get { return isInput; } set { isInput = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsBattle_Idle { get { return isBattle_Idle; } set { isBattle_Idle = value; } }
    public bool IsSkilluse_1 { get { return isSkilluse_1; } set { isSkilluse_1 = value; } }
    public bool IsSkilluse_2 { get { return isSkilluse_2; } set { isSkilluse_2 = value; } }
    public bool IsSkilluse_3 { get { return isSkilluse_3; } set { isSkilluse_3 = value; } }
    public bool IsSkilluse_4 { get { return isSkilluse_4; } set { isSkilluse_4 = value; } }



    public State CurrentState { get { return currentState; } set { currentState = value; } }

    //캐릭터 행동 상태
    ///읽기 전용
    public State_Attack AttackState { get { return attackState; } }
    public State_Death DeathState { get { return deathState; } }
    public State_Dodge DodgeState { get { return dodgeState; } }
    public State_Guard GuardState { get { return guardState; } }
    public State_Hit HitState { get { return hitState; } }
    public State_Idle IdleState { get { return idleState; } }
    public State_Move MoveState { get { return moveState; } }
    public State_Battle_Idle BattleIdleState { get { return battle_idleState; } }
    public State_SkillUse SkillUseState { get { return skillUseState; } }
    public State_TargetSearch TargetSearchState { get { return targetSearchState; } }

    //캐릭터 이동 방향
    public Vector3 Move_Direction { get { return move_Direction; } set { move_Direction = value; } }
    public float PrevMoveDirection_X { get { return prevMoveDirection_X; } set { prevMoveDirection_X = value; } }

    //공격 방향
    public Vector3 Attack_Direction { get { return attack_Direction; } set { attack_Direction = value; } }

    //공격 대상 레이어 마스크
    ///읽기 전용
    public LayerMask Enemy_layerMask { get { return enemy_LayerMask; } }


    //Epuip
    ///Weapon
    public Weapon Right_Hand { get { return right_Hand; } set { right_Hand = value; } }
    public Weapon Left_Hand { get { return left_Hand; }set { left_Hand = value; } }


    #endregion







    protected virtual void Awake() 
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //Animation
        myAnimator = GetComponent<Animator>();


        //State
        attackState = GetComponent<State_Attack>();
        deathState = GetComponent<State_Death>();
        dodgeState = GetComponent<State_Dodge>();
        guardState = GetComponent<State_Guard>();
        hitState = GetComponent<State_Hit>();
        idleState = GetComponent<State_Idle>();
        moveState = GetComponent<State_Move>();
        battle_idleState = GetComponent<State_Battle_Idle>();
        skillUseState = GetComponent<State_SkillUse>();
        targetSearchState = GetComponent<State_TargetSearch>();
    }

    private void Start()
    {
        characterObjectManager = GameObject.Find("CharacterObjectManager").GetComponent<CharacterObjectManager>();

        characterObjectManager.AddObjectList(this);
    }
}
