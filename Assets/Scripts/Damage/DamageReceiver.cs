using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : GameMonoBehaviour
{
    [SerializeField] protected static DamageReceiver instance;
     public static DamageReceiver Instance=> instance;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected double currentHp;
    [SerializeField] protected double hpMax ;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected float  yColliderPos = -0.7f;
  

    public double CurrentHp => currentHp;
    public double HpMax => hpMax;

 
    protected override void OnEnable()
    {
        this.Reborn();

    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
  
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.5f;
        this.sphereCollider.isTrigger = true;
        Vector3 currentCenter = this.sphereCollider.center;
        currentCenter.y = yColliderPos;
        this.sphereCollider.center = currentCenter;
        Debug.LogWarning(transform.name + "||LoadSpherreCollider||", gameObject);

    }
    public virtual void Reborn()
    {
        this.currentHp = this.hpMax;
        this.isDead = false;
    }
    public virtual void Health(int value)
    {
        if (this.isDead) return;
        this.currentHp += value;
        if (this.currentHp > hpMax) this.currentHp = this.hpMax;
    }
     public virtual void TakeDame(double value)
    {
        if (this.isDead) return;
        this.currentHp -= value;
        if (this.currentHp <= 0) this.currentHp = 0;
        this.CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return this.currentHp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();

    }
    public virtual void SetHpMax(double hpMax)
    {
        this.hpMax = hpMax;
    }public virtual void SetCurrentHp(double currentHp)
    {
        this.currentHp = currentHp;
    }
    public abstract void OnDead();

}
