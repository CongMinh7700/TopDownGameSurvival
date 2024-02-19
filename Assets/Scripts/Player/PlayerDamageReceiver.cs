using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [Header("Damage Receiver")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }
   
    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent?.GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning(transform.name + "||LoadShootableObjectCtrl||", gameObject);
    }
    public override void OnDead()
    {
        GameManager.Instance.GameOver();
    }
    public override void Reborn()
    {
        this.hpMax = this.shootableObjectCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
