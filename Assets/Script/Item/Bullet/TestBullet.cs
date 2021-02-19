using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : BaseBullet
{
    private void Start()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
        BulletCreatedTest();
    }
    private void FixedUpdate()
    {
        BulletMove();
    }
    // Start is called before the first frame update
    public override void BulletCreatedTest()
    {
        if (this != null)
        {
            Debug.Log("TestBullet Created");
        }
    }
    public override void BulletMove()
    {
        _bulletRigidbody.velocity = transform.forward * _bulletSpeed;
    }

    protected override void BulletHitEnemy(GameObject target)
    {
        target.GetComponent<BaseEnemy>().GetDamage(this);
        Destroy(this.gameObject);
    }
    protected override void BulletHitWall()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("TestBullet HIt Enemy");
            BulletHitEnemy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("TestBullet Hit Wall");
            BulletHitWall();
        }

    }
}
