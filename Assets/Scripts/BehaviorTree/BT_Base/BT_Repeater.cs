using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Repeater(Loop)

repeater는 자식 노드가 결과를 반환할 때마다 자식 노드를 재처리한다.
보통 트리의 맨 밑부분에서 사용되는데 반복 실행하기 위해서 사용한다.
repeater는 부모에게 돌아가기 전에 자식 노드에게 정해진 횟수를 선택적으로 실행할 수 있다.
 */
public class BT_Repeater : BT_Decorate
{
    public override bool Run()
    {
        return true;
    }
}
