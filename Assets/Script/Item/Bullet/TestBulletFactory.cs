using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletFactory : BaseBulletFactory
{
    public override BaseBullet CreateBullet()
    {
        Debug.Log("BaseBullet Created by BaseBulletFactory");

        return new TestBullet();
    }
}
