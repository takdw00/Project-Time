using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 Decorator

Decorator는 하나의 자식 노드만 가질 수 있음
Decorator의 기능은 자식 노드의 상태로부터 받은 결과를 변형시키거나, 자식 노드를 종료시키거나, 장식 노드 유형에 따라 자식 노드의 처리를 반복하는 것이다.
조건을 만족하면 자식을 실행하고, 조건을 만족하지 못하면 false 를 반환 = 조건문 느낌
Decorator가 지정하는 조건을 만족했을 경우의 반환 결과는 자식의 반환 결과에 의존함
일반적으로 사용되는 invert 노드: 단순히 자식 노드의 결과를 뒤집는다.(!= 인듯) 자식 노드가 실패하면 부모에게 성공을 돌려주거나, 자식 노드가 성공해서 부모에게 실패를 돌려준다.
 */

//Decorate 를 상속 받은 클래스는 Run을 구현해야한다.
//Run은 특정 조건을 물어봐야한다.
//특정 조건이 만족 될 경우 자식노드의 Run을 실행하도록 한다.

public abstract class BT_Decorate : BT_Node
{
    BT_Node childNode;

    protected BT_Node GetChildNode() { return childNode; }
    public void AddChildNode(BT_Node node)
    {
        childNode = node;
    }


}