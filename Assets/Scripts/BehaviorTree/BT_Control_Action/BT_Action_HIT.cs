using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_HIT : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsHit)
        {
            character.CurrentState=character.HitState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
