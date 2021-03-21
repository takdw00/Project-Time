using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLog : MonoBehaviour
{
    //안씀





    TimeManager timeManager;
    //CharacterObjectManager characterObjectManager;

    ArrayList allTimeLog;
    ArrayList currentObjects;

    private void Awake()
    {
        timeManager = GetComponent<TimeManager>();
    }

    private void Start()
    {
        //characterObjectManager = GameObject.Find("CharacterObjectManager").GetComponent<CharacterObjectManager>();
    }

    private void Update()
    {
        
    }

    void SetAllTimeLog()
    {
        if(timeManager.isLogRecode)
        {
            //chara
        }

    }

    void SetCurrentObjects()
    {
        
    }
}
