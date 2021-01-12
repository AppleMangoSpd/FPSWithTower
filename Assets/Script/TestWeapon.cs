using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour, IWeapon
{

    public IBullet _bullet;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TestWeapon Start");
        Debug.Log("TestWeapon is kind of gun");
    }

    public void UsingWeapon()
    {
        this.Fire();
    }

    private void Fire() 
    { 
    }
}
