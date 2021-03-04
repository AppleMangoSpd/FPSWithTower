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
    [SerializeField]
    protected float _bulletDamage;
    public float bulletDamage
    {
        get { return _bulletDamage; }
        set { _bulletDamage = value; }
    }
    [SerializeField]
    protected Vector3 _bulletSpawnPosition;

    public Transform _firePos;

    public void SetBulletSpawnPosition(Vector3 inputPosition)
    {
        _bulletSpawnPosition = inputPosition;
    }    

    public virtual void BulletCreatedTest()
    {
        if (this != null)
        {
            Debug.Log("BaseBullet Created");
        }
    }
    public virtual void BulletMove()
    {
        Debug.Log("BaseBullet's BulletMove() called");
    }
    protected virtual void BulletHitEnemy(GameObject target)
    {
        Debug.Log("BaseBullet's");
        target.GetComponent<BaseEnemy>().GetDamage(this);
        Destroy(this.gameObject);
    }
    protected virtual void BulletHitWall()
    {
        Destroy(this.gameObject);
    }

    protected virtual void BulletHitPlayer()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Base Bullet HIt Enemy");
            BulletHitEnemy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Base Bullet HIt Wall");
            BulletHitWall();
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Base Bullet HIt Player");
            BulletHitPlayer();
        }
    }
}
