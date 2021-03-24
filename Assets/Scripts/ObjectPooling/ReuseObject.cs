using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReuseObject : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    ObjectPool parentObject;
    Gun myGun;


    [SerializeField] public bool isDie;
    float nowDelay;
    public float speed;
    [SerializeField] float lifeTime;
    Vector3 moveDirection;



    //properties
    public Gun MyGun { get { return myGun; } set { myGun = value; } }


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //Debug.Log("발사체 스타트()");
        parentObject = transform.parent.GetComponent<ObjectPool>();
        //gun = transform.parent.transform.parent.transform;
    }


    private void FixedUpdate()
    {
        RotationProjectile(moveDirection);
        BulletMove(moveDirection);
    }
    // Update is called once per frame
    void Update()
    {

        CheckLife(); // 오브젝트의 생존 여부 판단
        if (isDie)
        {
            parentObject.ReturnBullet();
        }
    }

    public void SetBullet(GameObject gameObject, Vector3 direction, float objectSpeed)
    {
        // 오브젝트 활성화 시 시작 위치 초기화
        this.gameObject.transform.position 
            = new Vector3(myGun.transform.position.x, myGun.transform.position.y, 0);
        moveDirection = direction;
        speed = objectSpeed;
    }
    void CheckLife() // 오브젝트의 생존 여부 판단
    {
        // 1. 오브젝트가 1초 이상 활성화 될 경우 죽었다고 판단한다.
        nowDelay += Time.deltaTime;
        if (nowDelay > lifeTime)
        {
            isDie = true;
            nowDelay = 0;
        }
    }

    public void BulletMove(Vector3 direction)
    {
        Vector3 moveRes = direction * speed * Time.deltaTime;
        myRigidbody.MovePosition(transform.position + moveRes);
    }

    // 오브젝트가 활성화 될 때
    private void OnEnable()
    {
        myRigidbody.velocity = Vector3.forward * speed;
    }
    // 오브젝트가 비활성화 될 때
    private void OnDisable()
    {
        myRigidbody.Sleep();
    }

    void RotationProjectile(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
