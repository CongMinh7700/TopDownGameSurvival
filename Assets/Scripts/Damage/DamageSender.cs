using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : GameMonoBehaviour
{
    [SerializeField] protected double damage = 1;
    public double Damage => damage; 
    [SerializeField] protected double preDamage = 1;
    public double PreDamage => preDamage;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
       
    }
    public virtual void Send (DamageReceiver damageReceiver)
    {
        damageReceiver.TakeDame(this.damage);
    }
    public virtual void IncreaseDamageSkill(double value)
    {
        this.damage += value;
    }
    public virtual void ResetDamageSkill()
    {
        this.damage = preDamage; 
    }
    public virtual void DisplayDamageTest()
    {
     
    }
    public virtual void SetMaxDamage(double damage)
    {
        this.damage = damage;
    }
    public virtual void SetPreviousDamage(double damage)
    {
        preDamage = damage;
    }
}
