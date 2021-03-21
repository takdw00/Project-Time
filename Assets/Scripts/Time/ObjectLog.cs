using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLog : MonoBehaviour
{
    //TimeLog timeLog;

    static int logNumber;

    TimeManager timeManager;
    float logCycleTime;

    Stack log;

    ObjectAction currentObject;
    ObjectAction previousObject;

    Character character;

    private void Awake()
    {
        log = new Stack();
        character = GetComponent<Character>();
    }
    private void Start()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }



    public void SetLogList()
    {
        logNumber += 1;
        currentObject = new ObjectAction();
        currentObject.logNumber = logNumber;
        SetLog(currentObject);
        log.Push(currentObject);
        Debug.Log("로그 번호 : "+currentObject.logNumber + "  기록중..." + currentObject.Character.gameObject.name + " 의 기록 " + " 시간 : " + currentObject.Time + " 좌표 : " + currentObject.Position + "기록 방향 : "+currentObject.Direction);

    }

    public ObjectAction GetLog()
    {
        if(log.Count!=0)
        {
            previousObject = (ObjectAction)log.Pop();

            return previousObject;
        }
        return null;
    }

    public void LogRegistered()
    {

    }

    void SetLog(ObjectAction curobj)
    {
        curobj.Character = character;
        curobj.Time = timeManager.time;
        curobj.Position = character.transform.position;
        curobj.Direction = character.Move_Direction;
        curobj.Speed = character.Now_Speed;
        curobj.State = character.CurrentState;
        //curobj.AnimatorController = character.CurrentState.AnimatorController_CharacterState;
    }

    public void LogReplay()
    {

    }
}
