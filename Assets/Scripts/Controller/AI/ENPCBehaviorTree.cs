using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENPCBehaviorTree : CharacterControl
{
    //�� Ŭ������ ENPC AI�� �⺻�� �Ǵ� Ŭ�����̴�.
    //�� Ŭ������ ��� �޾� �پ��� AI Ŭ������ ���� ����ϵ��� �Ѵ�.

    ENPCharacter character;

    private void Awake()
    {
        character = transform.parent.GetComponent<ENPCharacter>();
        character.Enemy_AI = GetComponent<ENPCBehaviorTree>();

        //�б� ���
        sel_CharacterState = gameObject.AddComponent<BT_Selector>();
        seq_Enemy_AI_Status_Branch = gameObject.AddComponent<BT_Sequence>(); // AI�� �Ǵ��ؼ� �Է�ó��
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();

        //�׼� ���
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_ENEMY_AI = gameObject.AddComponent<BT_Action_ENEMY_AI>();
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
    }

    private void Start()
    {
        //AI controller

        //���߿� dead ���� ���� �� ��.
        sel_CharacterState.AddChildNode(seq_Enemy_AI_Status_Branch); //��� �׼�

        seq_Enemy_AI_Status_Branch.AddChildNode(action_ENEMY_AI); //AI �Ǵ�
        seq_Enemy_AI_Status_Branch.AddChildNode(sel_Status_Replacement_Branch); //�������ͽ� ���� �б�

        sel_Status_Replacement_Branch.AddChildNode(action_ATTACK); // ȸ�� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); // �̵� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_IDLE); // ���
        //sel_Status_Replacement_Branch.AddChildNode(action_SKILL_USE); //��ų ��� �׼� ,���� ���� �ʿ��� �� ����.
    }

    public override void ControlCommand()
    {
        if(sel_CharacterState!=null)
        {
            sel_CharacterState.Run();
        }
        else
        {
            return;
        }

    }
}
