using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : BaseWeapon
{

    // Start is called before the first frame update
    void Start()
    {
        //_bullet = TestBullet;
        Debug.Log("TestWeapon Start");
        Debug.Log("TestWeapon is kind of gun");
        //Debug.Log("Cuurent Bullet is " + _bullet.ToString());
    }

    private void Update()
    {
        if(_isFire)
        {
            Fire();
            _isFire = false;
        }
    }
    protected virtual void BulletcreatedTest()
    {

    }
    public override void UseWeapon()
    {
        _isFire = true;
    }

    private void Fire() 
    {
        _isFire = true;
        float bulletSpawnDistance = 1.5f;

        Vector3 bulletDir = transform.forward * bulletSpawnDistance;
        //_bullet = _testBulletFactory.CreateBullet();
        Vector3 targetPos = _firePos.transform.TransformPoint(_firePos.transform.forward);
        BaseBullet baseBullet = Instantiate(_bullet, targetPos, Quaternion.identity);
        baseBullet.SetBulletSpawnPosition(targetPos);
        Debug.Log("Test Weapon fired");
    }
}
