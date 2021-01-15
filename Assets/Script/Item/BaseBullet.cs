using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour, IBullet
{
    protected Rigidbody _bulletRigidbody;

    [SerializeField]
    protected float _bulletSpeed;
    public float bulletSpeed
    {
        get { return _bulletSpeed; }
        set { _bulletSpeed = value; }
    }
    protected Vector3 _bulletDirection;
    public float bulletDirection;

   
    void Start()
    {
        BulletCreatedTest();
    }

    public virtual void BulletCreatedTest()
    {
        Debug.Log("BaseBullet Created");
    }

    public virtual void BulletMove()
    {
        Debug.Log("BaseBullet's BulletMove() called");
    }
}
