using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Hit : State , IDamageable
{
    public override void Execution()
    {
        TakeDamage();
        CharacterRef.IsHit = false;
    }

    public override void Animation()
    {

    }

    public void TakeDamage()
    {
        Debug.Log("대미지를 입음.");
    }
}
