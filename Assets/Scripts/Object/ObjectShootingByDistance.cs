using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShootingByDistance : ObjectShooting
{
    [SerializeField] protected float distance;
    [SerializeField] protected float disLimit = 20f;
    [SerializeField] protected Transform playerTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerTarget();
    }
    protected override void ResetValue()
    {
        this.shootDelay = 2.5f;
    }
    protected virtual void LoadPlayerTarget()
    {
        if (this.playerTarget != null) return;
        this.playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(transform.name + "||LoadPlayerTarget||", gameObject);
    }
    protected override bool IsShooting()
    {
        distance = Vector3.Distance(transform.position,playerTarget.position);
        this.isShooting = distance <= disLimit;
        return isShooting;
    }
}
