using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : GameMonoBehaviour
{
    [SerializeField] protected int enemyKillCount = 0;
    [SerializeField] protected int enemyKillLimit = 16;
    public virtual int EnemeyKilled()
    {
        this.enemyKillCount++;
        return this.enemyKillCount;
    }
    public virtual bool CanSpawnBoss()
    {

        if (enemyKillCount % enemyKillLimit == 0) return true;
        return false;
    }
}
