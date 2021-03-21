using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Composite

복합 노드는 하나 이상의 자식을 가질 수 있는 노드
자식 노드 중 하나 이상을 문제의 특정 복합 노드에 따라 첫 번째에서 마지막 순서로 또는 무작위 순서로 처리함
어떤 단계에서는 처리 완료를 고려하고 종종 자식 노드의 성패를 부모 노드에게 성공 또는 실패 중 하나를 전달한다.
부모 노드가 자식 노드의 결과를 처리하는 동안 자식 노드는 계속해서 부모 Running를 반환한다.
일반적으로 사용되는 복합 노드는 Sequence
Sequence는 각 자식 노드를 순서대로 실행하며, 자식 노드 중 한 명이 실패하는 지점에서 failure를 반환하고 모든 자식 노드가 Success를 반환하면 부모 노드에게 Success을 반환한다.
 */

public abstract class BT_Composite : BT_Node
{
    List<BT_Node> childNodeList = new List<BT_Node>();
    protected List<BT_Node> GetChildNode() { return childNodeList; }
    public void AddChildNode(BT_Node node)
    {
        childNodeList.Add(node);
    }
}
