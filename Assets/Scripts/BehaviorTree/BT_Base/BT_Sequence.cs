using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Sequence

자식 노드를 순서대로 실행하기 위한 노드
평가를 시작하면 sequence의 자식 노드를 왼쪽에서 오른쪽(우선도가 높은 쪽에서 낮은 쪽)의 순서로 깊이 우선 탐색 방식으로 평가한다.
Sequence의 자식 노드 중 하나가 failure나 running을 반환하면 selector는 즉시 failure나 running을 부모 노드에 반환한다.
Selector의 모든 자식 노드가 success를 반환했을 때는 selector도 부모 노드에 success를 반환한다.
강력한 조건부 검사를 가능하게 한다.
AND 게이트와 유사하다.
Invert를 이용하여 NOT 게이트를 이용 가능하다.
Sequence를 이용하여 캐릭터나 게임 월드의 조건을 테스트하는 데 필요한 노드 양을 대폭 줄일 수 있다.
 */
public class BT_Sequence : BT_Composite
{
    public override bool Run()
    {
        foreach (var node in GetChildNode())
        {
            if (!node.Run())
            {
                return false;
            }
        }
        return true;
    }
}
