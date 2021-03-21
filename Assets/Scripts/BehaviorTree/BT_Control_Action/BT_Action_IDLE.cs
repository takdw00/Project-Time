using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_IDLE : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsIdle)
        {
            character.CurrentState = character.IdleState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
