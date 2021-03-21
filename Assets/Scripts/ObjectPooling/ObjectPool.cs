using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 참고
    // https://funfunhanblog.tistory.com/49
    // https://glikmakesworld.tistory.com/13

    // 오브젝트 풀 리스트?
    // 유니티의 Garbage Collector는 Compaction(압축,밀착)이 되지 않는다. 메모리 해제 역할만을 수행한다.  (매번 해체를 수행하면 성능적 문제가 생기나? 아니면 언제 GC가 시행 되는지 알 수 없나?)
    // Instantiate() , Destroy() 를 지속적으로 사용하게 되면 메모리의 단편화가 일어나게 된다.
    // 메모리의 단편화가 일어나게되면 이후에 새로운 메모리를 할당 할 떄 할당할 공간이 없어지는 문제가 생기게 된다.
    // 그런 문제를 방지하기 위해서 Loading(게임의 시작 과정)에서 사용할 오브젝트를 미리 할당 받아 놓고 비활성화를 상태로 보관한다.
    // 이후 사용할때만 오브젝틀 활성화해서 사용하고 사용이 끝난 오브젝트는 비활성화로 플레이에서 숨겨준다.

    // 장점?
    // 1. 메모리의 단편화를 방지 할 수 있다.
    // 2. 오브젝트가 생성 될 때 설정되야 할 많은 데이터로 인해서 렉이 발생 할 수 있는데
    //    게임 플레이 중 다수의 오브젝트를 생성하게 되면 플레이어는 프레임이 지연되는 상황을 겪을 수 도 있다.
    //    그래서 게임의 Loading에서 미리 처리한다.

    // 단점?
    // 1. 로딩 시간이 길어진다. (하지만 차라리 로딩이 긴게 낫다. 렉은 용납이 안된다.)

    // 추가 적으로 구현 해야할 점.
    // 일정 상황 마다 오브젝트 풀 리스트의 수를 초기화 해줘야한다.
    // 현재는 오브젝트 풀 리스트가 생성 되면 줄어들지 않는다.


    // 기능만 구현하고 처리는 MyCube 클래스에서 처리한다.
    //
    // Initialize();    초기화 함수
    // MakeBullet();    오브젝트 풀 생성 함수
    // ReturnBullet();  오브젝트 반환 함수
    // Shoot();         오브젝트 활성화 함수














    //사용 리스트
    LinkedList<ReuseObject> listPool = new LinkedList<ReuseObject>();     // 오브젝트 풀
    LinkedList<ReuseObject> listActive = new LinkedList<ReuseObject>();   // 활성화 중인 오브젝트
    #region Lagacy Code (Not Use listDeActive)
    //LinkedList<Bullet> listDeActive = new LinkedList<Bullet>();     // 죽은 오브젝트(비활성화)
    #endregion 

    //설정할 것
    [SerializeField] GameObject bulletOrigin;                                    // 발사할 오브젝트
    [SerializeField] float objectSpeed; // 발사 오브젝트 속도
    //Transform parentObject;                                     // 부모 오브젝트로 설정할 오브젝트
    [SerializeField] int makeBulletCount = 10;                  // 오브젝트 풀의 크기




    private void Start()
    {
        Initialize();
    }

    public void Initialize() //오브젝트 풀 생성
    {
        // 1. 초기 생성 함수
        // 2. start 라인에서 실행 된다.
        // 3. 사용할 오브젝트와 설정 값을 준비.
        // 4. 오브젝트 풀을 생성한다.

        //parentObject = parentTransform;   // 부모가 될 오브젝트
        //bulletOrigin = bulletObject;    // 생성할 오브젝트 원형
        MakeBullet(makeBulletCount);    // 오브젝트 생성해서 풀에 넣어줄 함수
    }

    void MakeBullet(int CreateCount) // 오브젝트를 생성해서 풀에 넣어준다.
    {
        // 1. 카운트 만큼 오브젝트 풀 리스트를 생성한다.
        // 2. 생성 된 오브젝트를 설정 된 부모 오브젝트의 자식 오브젝트 설정한다.
        // 3. 생성 된 오브젝트는 비활성화 처리 한다.
        // 4. 오브젝트 풀 리스트에 생성 된 오브젝트를 추가한다.
        
        for(int i=0; i<CreateCount; i++)
        {
            var reuseObject = Instantiate(bulletOrigin).GetComponent<ReuseObject>();  // 오브젝트 생성 , 생성 된 오브젝트 개입을 하기 위한 연결
            reuseObject.transform.parent = transform;               // 생성 된 오브젝트의 부모 설정
            reuseObject.MyGun = transform.parent.transform.Find("Gun").GetComponent<Gun>();
            reuseObject.speed = objectSpeed;
            reuseObject.gameObject.SetActive(false);                             // 생성 오브젝트를 비활성화 해서 숨겨준다.
            listPool.AddLast(reuseObject);                                       // 생성 후 셋팅 된 오브젝트를 풀에 추가해준다.

        }
    }

    public void ReturnBullet() // 생성 된 오브젝트 중에 죽은 오브젝트는 임시 리스트에 넣어주는 함수
    {
        // 1. 활성화 된 리스트에서 죽었다고 판단 되는 오브젝트를 찾는다.
        // 2. 활성화 리스트에서 삭제한다.
        // 3. 오브젝트를 비활성화 한다.
        // 4. 오브젝트에서 사용되는 값을 초기화한다. (오브젝트 초기화)

        foreach(var reuseObject in listActive) // 활성화 된 오브젝트 중 죽은 판단이 된 것들은 비활성화 리스트에 넣어준다.
        {
            if(reuseObject.isDie) // 총알이 죽었는가?
            {
                listPool.AddLast(reuseObject);           // 오브젝트 풀 리스트에 추가해준다.
                //listDeActive.AddLast(bullet);     // 비활성화 리스트에 추가해준다.
                listActive.Remove(reuseObject);          // 활성화 리스트에서는 삭제한다.
                reuseObject.gameObject.SetActive(false); // 오브젝트를 비활성화 해준다.
                reuseObject.isDie = false;               // 오브젝트의 생존 여부를 다시 false로 바꿔준다.
                break;
            }
        }

        #region Legacy Code (Not Use listDeActive)
        //foreach(var bullet in listDeActive)
        //{
        //    listPool.AddLast(bullet); // 비활성화 리스트에서 오브젝트 풀 리스트로 추가해준다.
        //    bullet.gameObject.SetActive(false); //비활성화 해준다.
        //    bullet.isDie = false; // 비활성화 된 오브젝트의 생존 여부를 다시 false 로 바꿔준다.
        //}
        //listDeActive.Clear(); // 임시 리스트에서 풀 리스트로 다 옮겨줬다면 리스트를 비워준다.
        #endregion
    }

    public void EnableObject(Vector3 direction) // 탄환(오브젝트)발사 , 활성화 함수
    {
        // 1. 오브젝트 풀 리스트의 카운트를 검사한다.
        // 2. 오브젝트 풀 리스트가 비어 있을 경우 오브젝트 풀 리스트를 추가 생성한다.
        // 3. 활성화 할 오브젝트를 오브젝트 풀 리스트에서 받아온다.
        // 4. 받아온 오브젝트는 오브젝트 풀 리스트에서 삭제한다.
        // 5. 받아온 오브젝트의 값을 설정해주고 활성화 한다.
        // 6. 활성화 된 오브젝트는 활성화 리스트에 추가한다.

        if(listPool.Count==0)
        {
            //총을 쏘았을때 생성 된 총알이 아직 비활성화 처리 이후에 풀로 돌아오지 않은 경우다.
            MakeBullet(makeBulletCount);    // 오브젝트 풀의 카운트가 0일 경우, 오브젝트 추가 생성한다.
        }
        
        var reuseObject = listPool.First.Value;  // 발사 할 오브젝트를 풀 리스트에서 받아온다.
        listPool.RemoveFirst();             // 받아온 오브젝트는 풀에서 삭제한다.
        reuseObject.SetBullet(this.gameObject, direction, objectSpeed);  // 발사 할 오브젝트의 값을 셋팅 해준다.
        reuseObject.gameObject.SetActive(true);  // 발사 할 오브젝트 활성화
        listActive.AddLast(reuseObject);         // 발사한 오브젝트를 활성화중인 오브젝트 리스트에 추가해준다.
    }

    #region Incomplete code (Pool Clear)
    //public void ClearPoolList() // 오브젝트 풀 리스트를 초기화 해준다.
    //{
    //    if(listPool.Count!=0)
    //    {
    //        foreach (var bullet in listPool)
    //        {
    //            Debug.Log(bullet.name + "삭제");
    //            Destroy(bullet);    // 반복문 순회, 모든 오브젝트 삭제.
    //        }
    //        listPool.Clear();       // 리스트 삭제
    //    }
    //}
    #endregion
}
