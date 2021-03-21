using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObjectManager : MonoBehaviour
{

    public List<Character> characterList = new List<Character>();
    

    public void AddObjectList(Character character)
    {
        characterList.Add(character);

    }
}
