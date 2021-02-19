using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour, IWeapon
{
    protected float _timer;
    [SerializeField]
    protected float _waitingTime;
    [SerializeField]
    protected bool _isFire;
    [SerializeField]
    protected Transform _firePos;
    [SerializeField]
    protected BaseBullet _bullet;

    private void Start()
    {
    }
    public virtual void UseWeapon()
    {
        Debug.Log("BaseWeapon Used");
    }
    public virtual bool CountingDelayTime()
    {
        return false;
    }
}
