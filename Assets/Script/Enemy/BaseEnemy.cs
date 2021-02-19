using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyEvent
{
    ENEMY_DEATH
}

public class BaseEnemy : MonoBehaviour, IObserver
{
    [SerializeField]
    protected float _hp;
    [SerializeField]
    protected float _speed;
    protected Notifier _notifier;

    private void Start()
    {
        Debug.Log("BaseEnemyStartCalled");

    }

    public virtual void GetDamage(BaseBullet hitter)
    {
        Debug.Log("BaseEnemy Got Damage by" + hitter.ToString());
        _hp -= hitter.bulletDamage;
        if(_hp <=0)
        {
            _notifier.Notify((int)EEnemyEvent.ENEMY_DEATH);
        }
    }

    protected virtual void OnDeath()
    {
        Destroy(this.gameObject);
    }
    public void OnNotify(int inputEvent)
    {
        EEnemyEvent eEnemyEvent = (EEnemyEvent)inputEvent;
        switch (eEnemyEvent)
        {
            case EEnemyEvent.ENEMY_DEATH:
            {
                 Debug.Log(this.name.ToString() + " is dead");
                 OnDeath();
            }
            break;

            default:
                break;
        }

    }

}
