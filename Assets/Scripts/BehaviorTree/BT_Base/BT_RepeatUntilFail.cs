using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Repeat Until Fail

자식 노드가 실패를 반환할 때까지 자식 노드를 반복 실행한다.
실패를 반환하면 부모에게 성공을 반환한다.
 */
public class BT_RepeatUntilFail : BT_Decorate
{
    public override bool Run()
    {
        return true;
    }
}
