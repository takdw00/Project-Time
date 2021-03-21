using UnityEngine;

public class State_Move : State
{
    private void Awake()
    {
        base.Awake();
        animation_Speed = 1;
    }

    public override void Execution()
    {
        Vector3 moveRes = CharacterRef.Move_Direction * CharacterRef.Now_Speed * Time.deltaTime;
        CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);
        //Debug.Log("X : "+CharacterRef.Movement.x+" Y : "+CharacterRef.Movement.y);
    }

    public override void Animation()
    {
        CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;

        if(timeManager.isTimeReset)
        {
            CharacterRef.Look_Direction = -CharacterRef.Move_Direction;
        }
        else
        {
            CharacterRef.Look_Direction = CharacterRef.Move_Direction;
        }

        if(CharacterRef.Look_Direction.x==0)
        {
            CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.PrevMoveDirection_X);
            CharacterRef.MyAnimator.SetFloat("Direction_Y", 0);
        }
        else
        {
            CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Look_Direction.x);
            CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Look_Direction.y);
            CharacterRef.PrevMoveDirection_X = CharacterRef.Look_Direction.x;
        }
        CharacterRef.MyAnimator.speed = animation_Speed;
    }

}
