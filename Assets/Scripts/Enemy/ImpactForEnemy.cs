using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactForEnemy : BulletImpact
{
    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDamageSender();
    }
    protected override void Start()
    {
        this.sphereCollider.radius = 0.5f;
    }
    protected virtual void LoadEnemyDamageSender()
    {
        if (this.enemyDamageSender!= null) return;
        this.enemyDamageSender = transform.parent.GetComponentInChildren<EnemyDamageSender>();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.enemyDamageSender.Send(other.transform);
        }
    }
}
