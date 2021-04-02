using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENPCBehaviorTree : CharacterControl
{
    //이 클래스는 ENPC AI의 기본이 되는 클래스이다.
    //이 클래스를 상속 받아 다양한 AI 클래스를 만들어서 사용하도록 한다.

    ENPCharacter character;

    private void Awake()
    {
        character = transform.parent.GetComponent<ENPCharacter>();
        character.Enemy_AI = GetComponent<ENPCBehaviorTree>();

        //분기 노드
        sel_CharacterState = gameObject.AddComponent<BT_Selector>();
        seq_Enemy_AI_Status_Branch = gameObject.AddComponent<BT_Sequence>(); // AI가 판단해서 입력처리
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();

        //액션 노드
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_ENEMY_AI = gameObject.AddComponent<BT_Action_ENEMY_AI>();
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
    }

    private void Start()
    {
        //AI controller

        //나중에 dead 먼저 연결 할 것.
        sel_CharacterState.AddChildNode(seq_Enemy_AI_Status_Branch); //대기 액션

        seq_Enemy_AI_Status_Branch.AddChildNode(action_ENEMY_AI); //AI 판단
        seq_Enemy_AI_Status_Branch.AddChildNode(sel_Status_Replacement_Branch); //스테이터스 변경 분기

        sel_Status_Replacement_Branch.AddChildNode(action_ATTACK); // 회피 액션
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); // 이동 액션
        sel_Status_Replacement_Branch.AddChildNode(action_IDLE); // 대기
        //sel_Status_Replacement_Branch.AddChildNode(action_SKILL_USE); //스킬 사용 액션 ,이후 수정 필요할 수 있음.
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
