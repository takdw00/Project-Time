using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 Succeeder

Succeeders는 자식 노드가 실제로 무엇을 반환했든 상관없이 항상 성공을 반환한다.
이는 고장이 예상되거나 예상되는 트리의 분기를 처리하려는 경우 유용하지만 분기가 배치된 시퀀스의 처리를 포기하지는 않는다.
부모에 고장이 필요한 경우 inverter가 succeeder를 'failler'로 만들기 때문에 이 유형의 노드와 정반대가 필요하지 않다.
 */
public class BT_Succeeder : BT_Decorate
{
    public override bool Run()
    {
        return true;
    }
}
