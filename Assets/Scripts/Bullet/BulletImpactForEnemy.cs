using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactForEnemy : BulletImpact
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.bulletCtrl.BulletDamageSender.Send(other.transform);
        }
    }
}
