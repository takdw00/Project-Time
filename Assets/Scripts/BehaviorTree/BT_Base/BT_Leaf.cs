using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Leaf(다른 글의 = execution, action 노드인듯)

Leaf 노드는 가장 낮은 수준의 노드 유형이며 어떤 자식 노드도 가질 수 없다.
Leaf 노드는 당신의 게임에 의해 정의되고 구현되어 당신의 tree가 실제로 유용한 일을 하도록 만드는 데 필요한 특정한 게임이나 캐릭터 특정한 테스트나 행동을 하기 위해 실행될 것이기 때문에 가장 강력한 노드 타입이다.
- 예) Walk leaf 노드는 캐릭터가 지도상의 특정 지점까지 걸어가게 하고, 그 결과에 따라 성패가 반환된다.
Leaf 노드가 무엇인지 정의할 수 있기 때문에(종종 아주 최소의 코드를 가지고 있음) 
Leaf 노드는 Composite와 Decorators 아래에 층을 이룰 때 매우 표현력이 뛰어나며, 꽤 복잡하고 지능적으로 우선순위를 매긴 행동을 할 수 있는 꽤 강력한 행동 트리를 만들 수 있게 해준다.
- 게임 코드에 비유 Composite, Decorators = function
- leaf 노드 = 당신의 코드 흐름을 정의하기 위한 문장과 루프, AI 캐릭터의 행동, 상태 또는 상황 등 게임의 기능
Leaf 노드는 Parameter로 정의할 수 있다. 
- 예) Walk leaf 노드는 캐릭터가 걸어갈 좌표를 가질 수 있다.
파라미터는 AI 캐릭터가 트리를 처리하는 컨텍스트 안에서 저장된 변수를 얻을 수 있다.
- 예)걷기 위한 위치는 변수가 저장된 'GetSafeLocation' 노드에 의해 결정됨
- Walk 노드는 컨텍스트에 저장된 변수를 사용하여 목적지를 정의할 수 있음
다른 유형의 리프 노드는 행동 트리를 호출하는 것으로, 기존 트리의 데이터 컨텍스트를 호출된 트리에 전달한다. 특정한 변수 이름을 사용하여 셀 수 없이 많은 장소에서 재사용될 수 있는 행동 트리를 만들기 위해 모듈화할 수 있게 해주기 때문에 핵심이다.
- 예) 'Break to Building' 동작은 'TargetBuilding' 변수가 작동될 것으로 예상할 수 있으므로 부모 트리는 이 변수를
   컨텍스트에서 설정한 다음 하위 트리 leaf 노드를 통해 하위 트리를 호출할 수 있다.
 */

//추후 Leaf 클래스를 상속 받는 클래스는 액션 노드로써 어떤 행동에 대한 Run을 구현해야한다.
public abstract class BT_Leaf : BT_Node
{
    protected Character character;

    private void Awake()
    {
        character = transform.parent.GetComponent<Character>();
    }
    //자식노드에 다른 노드를 연결할 필요가 없으니 접근할 필요도 없음.

}
