using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_BATTLE_IDLE : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsBattle_Idle)
        {
            character.CurrentState = character.BattleIdleState;
            //Debug.Log("공격 대기 상태");
            return true;
        }
        else
        {
            return false;
        }
    }
}
