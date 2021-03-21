using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Dodge : State
{
    [SerializeField]  float front_Delay;
    float now_Front_Delay;
    [SerializeField] float back_Delay;
    float now_Back_Delay;

    [SerializeField] float dodgeSpeed;


    public override void Execution()
    {
        Dodge();

    }

    public override void Animation()
    {

    }

    void Dodge()
    {
        Debug.Log("����");

        now_Front_Delay += Time.deltaTime;
        if (now_Front_Delay > front_Delay)
        {
            CharacterRef.Now_Speed += dodgeSpeed;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            now_Back_Delay += Time.deltaTime;

            Vector3 moveRes = CharacterRef.Move_Direction * CharacterRef.Now_Speed * Time.deltaTime;
            CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);

            Debug.Log("ȸ��");
        }
        if (now_Back_Delay > back_Delay)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true; // �ִ� ��Ȳ�� ���� ���� �ʿ�
            now_Front_Delay = 0;
            now_Back_Delay = 0;
            CharacterRef.IsIdle = true;
            CharacterRef.IsDodge = false;
            CharacterRef.Now_Speed = CharacterRef.Defult_Move_Speed;
            Debug.Log("�ĵ�");
        }
    }

    //void Dodge()
    //{
    //    //Animator animator = CharacterRef.MyAnimator;

    //    //animator.runtimeAnimatorController
    //}

}
