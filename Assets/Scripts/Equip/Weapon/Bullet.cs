using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    
    //오브젝트 사용 변수
    Vector3 attackDirection;
    float speed;

    //애니매이션 사용 변수
    Animator myAnimator;
    float animation_Speed;




    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Execution();
    }
    private void Update()
    {
        //Animation();
    }

    public void Execution()
    {
        Vector3 moveRes = attackDirection * speed * Time.deltaTime;
        myRigidbody.MovePosition(transform.position + moveRes); 
    }

    public void Animation()
    {
        myAnimator.SetFloat("Direction_X", attackDirection.x);
        myAnimator.SetFloat("Direction_Y", attackDirection.y);
        myAnimator.speed = animation_Speed;
    }

    void SetAttackDirection(Vector3 direction)
    {
        attackDirection = direction;
    }
}
