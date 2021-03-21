using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    CharacterObjectManager characterObjectManager;

    List<ObjectAction> objectsAction = new List<ObjectAction>();

    public float time;
    public bool isTimeReset;
    public bool isLogRecode;
    public bool isTimeSaved;
    [SerializeField] float cycle_RecordingTime;
    float now_RecordingTime;
    [SerializeField] float cycle_ResetTime;
    float now_ResetTime;

    [SerializeField] float delay_TimeRest;
    float delay_Now_TimeRest;

    static int updateTime;
    static int fiexdTime;


    private void Awake()
    {
        isTimeSaved = true;
    }
    private void Start()
    {
        characterObjectManager = GameObject.Find("CharacterObjectManager").GetComponent<CharacterObjectManager>();
    }

    private void Update()
    {
        TimeRest_Cooltime();
        ResetExecution();
        SetTime();
        //updateTime += 1;
        //Debug.Log("updateTime " + updateTime);
    }
    private void FixedUpdate()
    {
        //fiexdTime += 1;
        //Debug.Log("fixedTime " + fiexdTime);
    }
    void SetTime()
    {
        if(!isTimeReset)
        {
            time += Time.deltaTime;
            now_RecordingTime += Time.deltaTime;
            if (now_RecordingTime >= cycle_RecordingTime) // timeCycle 의 주기마다 로그 기록
            {
                now_RecordingTime = 0;
                SetTimeLog();
            }
        }
    }

    public void SetTimeLog()
    {

        foreach (var charater in characterObjectManager.characterList)
        {
            charater.GetComponent<ObjectLog>().SetLogList(); // 리스트에 등록 된 오브젝트 순회하며 로그 기록
        }

    }


    //test01
    void ResetExecution()
    {
        // 모든 캐릭터의 제일 마지막에 기록 된 로그를 가져온다.
        if (isTimeReset)
        {
            now_ResetTime += Time.deltaTime;
            if (now_ResetTime >= cycle_ResetTime)
            {
                now_ResetTime = 0;

                foreach (var character in characterObjectManager.characterList)
                {
                    // 가져온 로그를 다른 리스트에 저장.
                    ObjectAction temp = character.GetComponent<ObjectLog>().GetLog();
                    if (temp != null)
                    {
                        objectsAction.Add(temp);
                    }
                }
                if (objectsAction.Count == 0)
                {

                    isTimeReset = false;
                    isTimeSaved = false;
                    Debug.Log("가져올 로그 없음.");
                    return;
                }

                Debug.Log("                     모든 캐릭터의 한 사이클 로그를 가져 옴...");
                // 가져온 로그를 실행 해야하기 때문에 false 로 바꿈
                //isResetCompleted = false;

                // 가져온 로그 리스트가 비어있지 않을 때.


                foreach (var objectAction in objectsAction)
                {
                    objectAction.ReplayAction();
                }
                time -= 1;
                objectsAction.Clear();
                //isResetCompleted = true; // 모든 로그의 리플레이가 완료 되면 true 로 바꿈

                Debug.Log("                         모든 캐릭터에 대해서 시간 리셋 한 사이클 진행 완료.");



            }

        }
    }

    public void SetIsTimeReset(bool isEnable)
    {
        isTimeReset = isEnable;
    }

    public void TimeRest_Cooltime()
    {
        if(!isTimeSaved)
        {
            delay_Now_TimeRest += Time.deltaTime;
            if (delay_Now_TimeRest >= delay_TimeRest)
            {
                delay_Now_TimeRest = 0;
                isTimeSaved = true;
            }
        }
    }
}
