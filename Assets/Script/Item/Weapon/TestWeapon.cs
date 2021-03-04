using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TestWeapon Start");
        Debug.Log("TestWeapon is kind of gun");
    }
    private void Update()
    {
        //PlayerInput 코드와 연관되지 않기 위해 이런 방식으로 코드생성
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
        
        BaseBullet baseBullet = Instantiate(_bullet, _firePos.position, Quaternion.identity);
        
        baseBullet._firePos = _firePos;
        baseBullet.BulletMove();
        Debug.Log("Test Weapon fired");
    }
}
