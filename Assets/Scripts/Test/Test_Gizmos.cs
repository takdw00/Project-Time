using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Gizmos : MonoBehaviour
{
    Vector3 range;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, range);
        Debug.Log("Attack Gizmos : " + transform.position + " // Range : " + range);
    }
}
