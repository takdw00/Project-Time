using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAction
{
    public int logNumber;
    Character character;
    bool isDodge;
    bool isIdle;
    bool isMove;
    float time;
    Vector3 position;
    Vector3 direction;
    float speed;
    State state;
    RuntimeAnimatorController animatorController;


    #region Properties
    public Character Character { get { return character;  } set { character = value; } }
    public bool IsDodge { get {return isDodge; } set { isDodge = value; } }
    public bool IsIdle { get { return isIdle; } set { isIdle = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public float Time { get { return time; } set { time = value; } }
    public Vector3 Position { get { return position; } set { position = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public State State { get { return state; } set { state = value; } }
    public RuntimeAnimatorController AnimatorController { get { return animatorController; } set { animatorController = value; } }

    #endregion

    public void ReplayAction()
    {

        character.CurrentState = state;
        character.IsDodge = isDodge;
        character.IsIdle = IsIdle;
        character.IsMove = IsMove;
        character.Now_Speed = speed;
        character.MyAnimator.runtimeAnimatorController = animatorController;
        character.Move_Direction = -direction;

        Debug.Log("로그 번호: " + logNumber + "    역재생 중 노출 시킨 데이터 " + character.Move_Direction);
        //Debug.Log("로그 번호 : " + logNumber + "                  시간 역재생 중 ... " + character.name + " 의 기록 " + " 시간 : " + time + " 좌표 : " + position + "기록 방향 : " + direction);
    }
}
