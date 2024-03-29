using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    private static BossSpawner instance;
    public static BossSpawner Instance => instance;


    protected override void Awake()
    {
        base.Awake();
        if (BossSpawner.instance != null) Debug.LogError("Only 1 BossSpawner allow to exist");
        BossSpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
       
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);
        return newEnemy;
    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HpBarSpawner.Instance.Spawn(HpBarSpawner.HpBar, newEnemy.position, Quaternion.identity);
        HpBar hpBar = newHpBar.GetComponent<HpBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
    }


}
