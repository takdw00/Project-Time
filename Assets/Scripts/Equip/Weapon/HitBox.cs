using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractableObject hitObject;

        //Debug.Log("On Trigger Endter");

        if (hitObject = collision.gameObject.GetComponent<InteractableObject>())
        {
            hitObject.IsHit = true;

            Debug.Log(gameObject.name + " Hit object : " + hitObject.gameObject.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //InteractableObject hitObject;

        //Debug.Log("On Trigger Stay");

        //if (hitObject = collision.gameObject.GetComponent<InteractableObject>())
        //{
        //    hitObject.IsHit = true;

        //    Debug.Log(gameObject.name + " Hit object : " + hitObject.gameObject.name);
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //InteractableObject hitObject;

        //Debug.Log("On Trigger Exit");

        //if (hitObject = collision.gameObject.GetComponent<InteractableObject>())
        //{
        //    hitObject.IsHit = true;

        //    Debug.Log(gameObject.name + " Hit object : " + hitObject.gameObject.name);
        //}
    }
}
