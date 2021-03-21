using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Action_SKILL_USE : BT_Leaf
{
    public override bool Run()
    {
        if (character.IsSkilluse_1)
        {
            character.CurrentState = character.SkillUseState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
