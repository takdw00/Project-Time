using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_ENEMY_AI : BT_Leaf
{
    public override bool Run()
    {
        //
        //AI 판단 부분 넣을 것
        character.IsIdle = true;
        //
        return true;
    }
}
