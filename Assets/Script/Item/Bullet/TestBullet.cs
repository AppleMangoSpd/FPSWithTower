using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : BaseBullet
{
    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
        BulletCreatedTest();
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
        _bulletRigidbody.velocity = _bulletSpeed * _firePos.forward;
    }

    //BulletHit-함수들과 충돌함수는 BaseBullet과 동일. 개선 필요
    protected override void BulletHitEnemy(GameObject target)
    {
        target.GetComponent<BaseEnemy>().GetDamage(this);
        Destroy(this.gameObject);
    }
    protected override void BulletHitWall()
    {
        Destroy(this.gameObject);
    }
    protected override void BulletHitPlayer()
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
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Base Bullet HIt Player");
            BulletHitPlayer();
        }
    }
}
