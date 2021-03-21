using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_TIMER : MonoBehaviour
{
    Text text_Time;
    public float time;


    private void Awake()
    {
        text_Time = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;

        text_Time.text = "Time " + System.Math.Truncate(time*100)/100;
    }
}
