using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENPCharacter : Character
{

    private void Start()
    {
        characterObjectManager = GameObject.Find("CharacterObjectManager").GetComponent<CharacterObjectManager>();

        characterObjectManager.AddObjectList(this);
    }
}
