using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    Character character;
    [SerializeField] ObjectPool objectPool;

    Vector3 mousePosition;
    Vector3 gunPosition;
    Vector3 attackDirection;

    [SerializeField] float gunMoveSpeed;

    public bool isAttack;


    //properties
    public Vector3 AttackDirection { get { return attackDirection; } set { attackDirection = value; } }

    private void Awake()
    {
        mousePosition = new Vector3(1,0,0);
        
    }
    private void Start()
    {
        character = transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();
    }
    private void FixedUpdate()
    {
        GunMove();
    }
    private void Update()
    {
        SetGunPosition();
        Shoot();
    }

    void SetGunPosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        mousePosition = mousePosition - transform.parent.transform.position;
        mousePosition = mousePosition.normalized;

        gunPosition = transform.parent.transform.position + mousePosition;

        //Vector3.Lerp(transform.position, gunPosition, gunMoveSpeed * Time.deltaTime);

    }
    
    void GunMove()
    {
        transform.position = gunPosition;
        //Vector3.Lerp(transform.position, gunPosition, gunMoveSpeed * Time.deltaTime);
    }

    public virtual void Shoot()
    {
       if(isAttack)
        {
            objectPool.EnableObject(attackDirection);
            isAttack = false;
        }
    }
}
