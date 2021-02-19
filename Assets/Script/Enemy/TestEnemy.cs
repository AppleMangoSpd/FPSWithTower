using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : BaseEnemy
{
    private void Start()
    {
        _notifier = new Notifier();
        _notifier.AddObserver(this);
    }
    public override void GetDamage(BaseBullet hitter)
    {
        Debug.Log("TestEnemy Got " + hitter.bulletDamage + "Damage by" + hitter.ToString());
        Debug.Log("Damage Result = " + _hp);

        _hp -= hitter.bulletDamage;
        if (_hp <= 0)
        {
            _notifier.Notify((int)EEnemyEvent.ENEMY_DEATH);
        }
    }
    protected override void OnDeath()
    {
        //Destroy(this.gameObject);
        base.OnDeath();
    }
}
