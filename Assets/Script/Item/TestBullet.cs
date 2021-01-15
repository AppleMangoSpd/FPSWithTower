using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : BaseBullet
{
    private void Start()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        BulletMove();
    }
    // Start is called before the first frame update
    public override void BulletCreatedTest()
    {
        Debug.Log("TestBullet Created");
    }
    public override void BulletMove()
    {
        //why use setter?
        _bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }
}
