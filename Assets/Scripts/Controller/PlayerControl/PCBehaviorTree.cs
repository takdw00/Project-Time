using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCBehaviorTree : CharacterControl
{
    PCharacter character;
    private void Awake()
    {
        //�θ� ������Ʈ character ��ũ��Ʈ�� ���� ���� �۾�
        character = transform.parent.GetComponent<PCharacter>();
        character.Player_Control = GetComponent<PCBehaviorTree>();

        //�б� ���
        sel_CharacterState = gameObject.AddComponent<BT_Selector>();
        seq_Input_Status_Branch = gameObject.AddComponent<BT_Sequence>();
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();

        //�׼� ���
        //action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
        action_INPUT = gameObject.AddComponent<BT_Action_INPUT>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        action_DODGE = gameObject.AddComponent<BT_Action_DODGE>();
        action_SKILL_USE = gameObject.AddComponent<BT_Action_SKILL_USE>(); //�ӽ�
    }
    private void Start()
    {
        //Player controller

        //���߿� dead ���� ���� �� ��.
        sel_CharacterState.AddChildNode(seq_Input_Status_Branch); //��� �׼�

        seq_Input_Status_Branch.AddChildNode(action_INPUT); //�Է� �׼�
        seq_Input_Status_Branch.AddChildNode(sel_Status_Replacement_Branch); //�������ͽ� ���� �б�

        sel_Status_Replacement_Branch.AddChildNode(action_DODGE); //ȸ�� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); //�̵� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_IDLE); // ���
        sel_Status_Replacement_Branch.AddChildNode(action_SKILL_USE); //��ų ��� �׼� ,���� ���� �ʿ��� �� ����.
    }
    public override void ControlCommand()
    {
        sel_CharacterState.Run();
    }
}
