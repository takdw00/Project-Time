using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_ATTACK : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsAttack)
        {
            character.CurrentState = character.AttackState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
