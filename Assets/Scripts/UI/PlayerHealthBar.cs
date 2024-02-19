using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{

    [SerializeField] protected double currentHp;
    [SerializeField] protected double maxHp;
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected float timeSafe = 1f;
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootSOCtrl();
        this.LoadPlayerDamageReceiver();
    }

    protected override void Start()
    {

        this.maxHp = this.shootableObjectCtrl.ShootableObject.hpMax;
        currentHp = maxHp;
        SetHpUI(currentHp,maxHp);
    }

    protected virtual void FixedUpdate()
    {
        this.Deduct();
    }
    protected virtual void LoadShootSOCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning(transform.name + "||LoadShootSOCtrl||", gameObject);
    } 
    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerDamageReceiver>();
        Debug.LogWarning(transform.name + "||LoadPlayerDamageReceiver||", gameObject);
    }
  

    public virtual void Deduct()
    {
        this.currentHp = playerDamageReceiver.CurrentHp;
        if (currentHp <= 0) currentHp = 0;
        SetHpUI(currentHp,maxHp);
        

    }
    protected virtual void Health(int value)
    {
        currentHp += value;
        if (currentHp >= maxHp) currentHp = maxHp;
        SetHpUI(currentHp, maxHp);
    }
}
