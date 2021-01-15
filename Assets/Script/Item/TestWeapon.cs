using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : BaseWeapon
{
    public BaseBullet _bullet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TestWeapon Start");
        Debug.Log("TestWeapon is kind of gun");
        Debug.Log("Cuurent Bullet is " + _bullet.ToString());
    }

    public override void UseWeapon()
    {
        Fire();
    }

    private void Fire() 
    {
        float bulletSpawnDistance = 1.0f;
        Debug.Log("Test Weapon fired");
        Vector3 bulletDir = transform.forward * bulletSpawnDistance; 

        Instantiate(_bullet, transform.position, Quaternion.identity);
    }
}
