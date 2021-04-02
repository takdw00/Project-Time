using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Selector

자식 노드 가운데 하나를 실행하기 위한 노드
평가를 시작하면 selector의 자식 노드를 왼쪽에서 오른쪽(우선도가 높은 쪽에서 낮은 쪽)의 순서로 깊이 우선 탐색 방식으로 평가한다.
Selector의 자식 노드 중 하나가 success나 running을 반환하면, selector는 즉시 success나 running을 부모 노드에 반환한다.
Selector의 모든 자식 노드가 failure를 반환했을 때는 selector도 부모 노드에 failure를 반환한다.
 */
public class BT_Selector : BT_Composite
{

    public override bool Run()
    {
        foreach(var node in GetChildNode())
        {
            //Debug.Log("Selector");
            if(node.Run())
            {
                return true;
            }
        }
        return false;
    }
}
