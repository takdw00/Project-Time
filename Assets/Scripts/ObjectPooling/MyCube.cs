using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCube : MonoBehaviour
{
    public ObjectPool objectPool;               // 오브젝트 풀 리스트 관리 함수
    public GameObject myBullet;                 // 오브젝트 풀에 추가할 오브젝트, 에디터에서 추가한다.

    public float bulletSpeed = 10.0f;           // 발사 오브젝트 스피드
    public float bulletLifeTime = 1.0f;         // 발사 오브젝트 한계 생존 시간

    #region Incomplete code (Pool Clear)
    //float currentTime;
    //public float initializationTime = 10.0f;    //오브젝트 풀 리스트 초기화 시간
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        objectPool = this.GetComponent<ObjectPool>();
        //objectPool.Initialize(this.gameObject.transform, myBullet);     // 오브젝트 풀 리스트 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     // 스페이스 클릭시 
        {
            //objectPool.Shoot();                 // 오브젝트 활성화 함수 호출
        }

        #region Incomplete code (Pool Clear)
        //currentTime += Time.deltaTime;          // 초기화 시간을 샌다.
        //Debug.Log(currentTime + "초");
        //if(currentTime> initializationTime)     // 초기화 시간 도달 시
        //{
        //    ammunition.ClearPoolList();         // 오브젝트 풀 리스트 초기화.
        //    currentTime = 0;
        //    Debug.Log("오브젝트 풀 리스트 초기화");
        //}
        #endregion
    }
}
