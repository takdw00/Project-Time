using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    private void Awake()
    {
        base.Awake();
        animation_Speed = 1;
    }
    public override void Execution()
    {
        //Debug.Log("Idle state");


    }

    public override void Animation()
    {
        CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
        if (CharacterRef.Move_Direction.x == 0)
        {
            CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.PrevMoveDirection_X);
            CharacterRef.MyAnimator.SetFloat("Direction_Y", 0);
        }
        else
        {
            CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Move_Direction.x);
            CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Move_Direction.y);
            CharacterRef.PrevMoveDirection_X = CharacterRef.Move_Direction.x;
        }
        CharacterRef.MyAnimator.speed = animation_Speed;

    }
}
