using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : ShootableObjectDamageReceiver
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.yColliderPos = -1.6f;
    }


    protected override void LoadSphereCollider()
    {
        base.LoadSphereCollider();
        this.sphereCollider.radius = 1.2f;
        Vector3 currentCenter = this.sphereCollider.center;
        currentCenter.y = -1.6f;
        this.sphereCollider.center = currentCenter;
    }
    public override void OnDead()
    {
        base.OnDead();
        GameManager.Instance.BossKilled();
        GameManager.Instance.UpdateScore(20);

    }
}
