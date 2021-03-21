using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    Text text_Time;
    float time;


    private void Awake()
    {
        text_Time = GetComponent<Text>();
        
    }


    // Update is called once per frame
    void Update()
    {
        SetTimer();
    }


    void SetTimer()
    {
        time = timeManager.time;
        text_Time.text = "Time " + System.Math.Truncate(time * 100) / 100;
    }


}
