using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{


    //BehaviorTree for player controller
    protected BT_Selector sel_CharacterState; // 전체 트리
    protected BT_Selector sel_Hit_Status_Branch; // 경직 액션 분기 시퀸스
    protected BT_Sequence seq_Input_Status_Branch; // 입력 액션 분기 셀렉터

    protected BT_Sequence seq_Enemy_AI_Status_Branch;

    protected BT_Selector sel_Status_Replacement_Branch; //스테이터스 변경 분기 셀렉터


    protected BT_Action_IDLE action_IDLE; // 기본 액션
    protected BT_Action_BATTLE_IDLE action_BATTLE_IDLE; // 공격 준비 액션
    protected BT_Action_HIT action_HIT; // 경직 액션
    protected BT_Action_INPUT action_INPUT; // 입력 액션

    protected BT_Action_ENEMY_AI action_ENEMY_AI; // 적 AI 판단

    protected BT_Action_DODGE action_DODGE; // 회피 액션
    protected BT_Action_GUARD action_GUARD; // 가드 액션
    protected BT_Action_MOVE action_MOVE; // 이동 액션
    protected BT_Action_ATTACK action_ATTACK; // 공격 액션
    protected BT_Action_SKILL_USE action_SKILL_USE; //임시  



    public virtual void ControlCommand()
    {

    }


}
