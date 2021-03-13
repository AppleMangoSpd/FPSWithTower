using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletFactory : IBulletFactory
{
    public override BaseBullet CreateBullet()
    {
        Debug.Log("BaseBullet Created by BaseBulletFactory");

        return new BaseBullet();
    }
}
