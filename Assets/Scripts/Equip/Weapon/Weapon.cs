using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;


    //무기 정보
    [SerializeField] protected float weaponDamage; // 무기 공격력
    [SerializeField] protected float weaponSpeed; // 무기 공격 속도

    //무기 이펙트 오브젝트
    [SerializeField] protected Effect weaponEffect;


    //무기 애니메이션 컨트롤러
    protected Animator myAnimator;

    //교체 무기 애니 컨트롤러
    //public RuntimeAnimatorController AinmationController_Battle_Idle;
    //public RuntimeAnimatorController AinmationController_Battle_Ready;
    //public RuntimeAnimatorController AinmationController_Battle_Run;
    //public RuntimeAnimatorController AinmationController_Battle_Walk;
    //public RuntimeAnimatorController AinmationController_Attack;
    //public RuntimeAnimatorController AinmationController_Dodge;
    //public RuntimeAnimatorController AinmationController_Guard;
    //public RuntimeAnimatorController AinmationController_Pary;
    //public RuntimeAnimatorController AinmationController_Hit;

    #region Properties
    //캐릭터
    public Character CharacterRef { get { return characterRef; }  set { } }

    //무기 정보
    public float WeaponSpeed { get { return weaponSpeed; } set { weaponSpeed = value; } }
    public Effect WeaponEffect { get { return weaponEffect; } set { }  }


    #endregion


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    //무기의 해당 상태의 애니메이션 컨트롤러
    private void Start()
    {

        characterRef = transform.parent.transform.parent.transform.parent.GetComponent<Character>();

        //weaponEffect = transform.Find("Weapon_Effect").gameObject.GetComponent<Effect>();
        
        //if(gameObject.name=="Long_Sword")
        //{
        //    Debug.Log("stop");
        //}
    }

    public void StateAction(RuntimeAnimatorController animatorController, Vector3 direction, float actionSpeed)
    {
        myAnimator.runtimeAnimatorController = animatorController;
        myAnimator.SetFloat("Direction_X", direction.x);
        myAnimator.SetFloat("Direction_Y", direction.y);
        myAnimator.speed = actionSpeed;
    }

    //public void StateAction(RuntimeAnimatorController animatorController, float animationNumber, float actionSpeed)
    //{
    //    myAnimator.runtimeAnimatorController = animatorController;

    //    myAnimator.SetFloat("Direction_X", animationNumber);
    //    myAnimator.speed = actionSpeed;
    //}

}
