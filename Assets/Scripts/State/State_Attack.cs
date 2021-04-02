using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    public override void Execution()
    {
    }

    public override void Animation()
    {
        if (!(AnimatorController_CharacterState == null))
        {
            CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
            CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Attack_Direction.x);
            CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Attack_Direction.y);

            //CharacterRef.MyAnimator.speed = CharacterRef.Right_Hand.WeaponSpeed;

            //CharacterRef.Right_Hand.StateAction(CharacterRef.Right_Hand.AinmationController_Attack, CharacterRef.Attack_Direction, CharacterRef.Right_Hand.WeaponSpeed);
            //CharacterRef.Right_Hand.WeaponEffect.StateEffect(CharacterRef.Right_Hand.WeaponEffect.AinmationController_Attack, CharacterRef.Attack_Direction, CharacterRef.Right_Hand.WeaponSpeed);

            //공격후 바라보는 방향 재정의
            CharacterRef.Move_Direction = CharacterRef.Attack_Direction;
        }
        else
        {
            return;
        }
    }


    //애니메이션에서 상태 전환 해줄 함수들
    public void AttackIng()
    {
        CharacterRef.IsAttack = false;
        //Debug.Log("캐릭터 공격 중");
    }
    public void AttackEnd()
    {
        CharacterRef.IsIdle = true;

        //Debug.Log("캐릭터 공격 종료");
        
    }

    public void Sprite_Sorting()
    {
        //CharacterRef.GetComponent<SpriteRenderer>().sor
    }
}
