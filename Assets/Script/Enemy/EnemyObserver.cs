using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EEnemyEvent
{
    ENEMY_DEATH
}


public class EnemyObserver : IObserver
{
    public void OnNotify(int enemyEvent)
    {
        switch (enemyEvent)
        {
            case (int)EEnemyEvent.ENEMY_DEATH
            { }

            

        }

    }
}
