using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : GameMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + "||LoadBulletCtrl||", gameObject);
    }
}
