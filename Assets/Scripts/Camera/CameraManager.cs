using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera myCamera;



    private void Awake()
    {
        myCamera = GetComponent<Camera>();

        myCamera.transparencySortMode = TransparencySortMode.CustomAxis;
        myCamera.transparencySortAxis = new Vector3(1, 1, 1);
    }


}
