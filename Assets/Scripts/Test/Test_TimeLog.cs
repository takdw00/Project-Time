using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_TimeLog : MonoBehaviour
{
    Test_TIMER timer;
    float time;
    float prev_time;

    bool isTimeRest;

    //GameObject myObject;

    Vector3 position;

    Stack position_log;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Test_Timer").GetComponent<Test_TIMER>();


        position_log = new Stack();
    }

    // Update is called once per frame
    void Update()
    {
        time = timer.time;

        if(isTimeRest)
        {
            TimeResetStart();
        }
        else
        {

            Log();
        }
        


    }



    void Log()
    {
        if(!isTimeRest)
        {
            if ((int)(time - prev_time) == 1)
            {
              
                prev_time = time;

                position_log.Push(transform.position);

                Debug.Log("Log " + time + " " + transform.position);

            }
        }
    }


    public void TimeReset()
    {
        isTimeRest = true;


    }

    void TimeResetStart()
    {
        if ((int)(time - prev_time) == 1)
        {
            transform.position = (Vector3)position_log.Pop();
             
            
            
            if (position_log.Count==0)
            {
                isTimeRest = false;
            }

        }
    }
}
