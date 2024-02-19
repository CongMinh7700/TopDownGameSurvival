using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    [SerializeField] protected static EnemyDespawn instance;
    public static EnemyDespawn Instance => instance;


    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
     
    }
   
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 100f;
    }
}
