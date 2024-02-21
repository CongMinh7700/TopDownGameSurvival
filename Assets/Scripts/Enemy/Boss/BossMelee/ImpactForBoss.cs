using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactForBoss : BulletImpact
{
    [SerializeField] protected BossDamageSender bossDamageSender;
    protected override void Start()
    {
        sphereCollider.radius = 1.3f;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossDamageSender();
    }
    protected virtual void LoadBossDamageSender()
    {
        if (this.bossDamageSender != null) return;
        this.bossDamageSender = transform.parent.GetComponentInChildren<BossDamageSender>();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.bossDamageSender.Send(other.transform);
        }
    }
}
