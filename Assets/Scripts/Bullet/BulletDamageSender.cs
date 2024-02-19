using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
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
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);

        Vector3 hitPos = transform.position;

        this.CreateTextDamageFx(hitPos);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
    protected virtual  string GetDamageText()
    {
        return FxSpawner.textDamage;
    }
    public virtual void CreateTextDamageFx(Vector3 hitPos)
    {
        string fxName = GetDamageText();
        Transform fxObj = FxSpawner.Instance.Spawn(fxName, hitPos, Quaternion.identity);
        TextDamage textDamage = fxObj.GetComponent<TextDamage>();
        textDamage.SetDamage(this.damage);
        fxObj.gameObject.SetActive(true);
    }
}

