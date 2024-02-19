using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactForPlayer : BulletImpact
{
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.bulletCtrl.BulletDamageSender.Send(other.transform);
        }
    }
}
