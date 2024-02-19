using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
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
        this.hpMax = shootableObjectCtrl.ShootableObject.hpMax;
        Debug.LogWarning(transform.name + "||LoadShootableObjectCtrl||", gameObject);
    }
    public override void OnDead()
    {
        this.OnDeadFx();
        this.OnDeadHurtSound();
        this.shootableObjectCtrl.Despawn.DespawnObject();
    }
    protected virtual void OnDeadFx()
    {
        string fxName = this.GetOnDeadFxName();
        Transform fxOndead = FxSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOndead.gameObject.SetActive(true);
    }
    protected virtual void OnDeadHurtSound()
    {
        string soundName = this.GetHurtSoundName();
        Transform fxOndead = FxSpawner.Instance.Spawn(soundName, transform.position, transform.rotation);
        fxOndead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFxName()
    {
        return FxSpawner.smoke_1;
    } 
    protected virtual string GetHurtSoundName()
    {
        return FxSpawner.hurtSound;
    }
   
}
