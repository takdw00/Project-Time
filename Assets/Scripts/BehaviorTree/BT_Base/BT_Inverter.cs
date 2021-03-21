using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Inverter

자식 노드의 결과를 뒤집거나 부정한다.
성공은 실패가 되고, 실패는 성공이 된다.
조건부에서 가장 자주 사용된다.
 */
public class BT_Inverter : BT_Decorate
{
    public override bool Run()
    {
        return true;
    }
}
