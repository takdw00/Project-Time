using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_DODGE : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsDodge)
        {
            character.CurrentState = character.DodgeState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
