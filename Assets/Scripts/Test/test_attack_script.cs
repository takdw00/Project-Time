using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_attack_script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter : "+other.name);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Stay : "+other.name);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Exit : " + other.name);
    //}
}
