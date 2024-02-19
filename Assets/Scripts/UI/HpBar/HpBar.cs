using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : GameMonoBehaviour
{
    [Header("HpBar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;


    protected virtual void FixedUpdate()
    {
        this.HpShowing();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSliderHP();
        this.LoadFollowTarget();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + "||LoadSpawner||", gameObject);
    }
    protected virtual void LoadSliderHP()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + "||LoadSliderHP||", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + "||LoadFollowTarget||", gameObject);
    }

    protected virtual void HpShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }
        double currentHp = this.shootableObjectCtrl.DamageReceiver.CurrentHp;
        double hpMax = this.shootableObjectCtrl.DamageReceiver.HpMax;
        this.sliderHp.SetCurrentHp(currentHp);
        this.sliderHp.SetHpMax(hpMax);

    }
    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }


}
