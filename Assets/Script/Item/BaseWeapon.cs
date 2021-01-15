using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour, IWeapon
{
    public virtual void UseWeapon()
    {
        Debug.Log("BaseWeapon Used");
    }

}
