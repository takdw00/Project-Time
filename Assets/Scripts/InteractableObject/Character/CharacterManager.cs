using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Character character;

    #region Properties
    public Character Character { get { return character; } }
    #endregion

    private void Start()
    {
        character = GetComponent<Character>();
    }

}
