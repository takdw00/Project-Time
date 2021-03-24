using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera myCamera;
    [SerializeField] Character character;

    private void Awake()
    {
        myCamera = GetComponent<Camera>();

        myCamera.transparencySortMode = TransparencySortMode.CustomAxis;
        myCamera.transparencySortAxis = new Vector3(1, 1, 1);
    }


    private void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (character.IsMove||character.IsDodge)
        {
            transform.Translate(character.Move_Direction * Time.deltaTime*character.Now_Speed);
        }
    }


}
