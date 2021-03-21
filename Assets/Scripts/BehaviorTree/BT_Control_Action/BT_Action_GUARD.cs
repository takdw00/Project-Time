using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_GUARD : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsGuard)
        {
            character.CurrentState = character.GuardState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
