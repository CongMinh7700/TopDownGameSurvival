using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeSkill : GameMonoBehaviour
{
    [SerializeField] protected BossMovement bossMovement;
    [SerializeField] protected Transform model;
    [Header("Boss Roll")]
    [SerializeField] protected float rollTime = 0.5f;
    [SerializeField] protected float rollDelay = 5f;
    [SerializeField] protected float rollBoost = 0.25f;
    [SerializeField] protected float damageBoost = 0.01f;
    [SerializeField] protected float moveSpeed  = 1f;

    [SerializeField] protected bool isRoll = false;
    [SerializeField] protected bool canRoll = false;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected BossDamageSender bossDamageSender;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadBossMovement();
        this.LoadBossDamageSender();
        this.LoadAnimator();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + "||LoadAnimator||", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.parent.Find("Model");

    }
    protected virtual void LoadBossMovement()
    {
        if (this.bossMovement != null) return;
        this.bossMovement = transform.parent.GetComponentInChildren<BossMovement>();
    } 
  
    protected virtual void LoadBossDamageSender()
    {
        if (this.bossDamageSender != null) return;
        this.bossDamageSender = transform.parent.GetComponentInChildren<BossDamageSender>();
    }
    protected virtual void Update()
    {
        Rolling();
    }
    protected virtual void Rolling()
    {
        if (this.canRoll)
        {
            animator.SetBool("Roll", true);
            isRoll = true;
            this.rollDelay = 5f;
            this.moveSpeed += rollBoost;
            this.bossMovement.SetMoveSpeed(moveSpeed);
    
            this.bossDamageSender.IncreaseDamageSkill(damageBoost);
        }
        this.RollCoolDown();
    }

    protected virtual void RollCoolDown()
    { 
        rollDelay -= Time.deltaTime;
        if (rollDelay <= 0)
        {
            rollDelay = 0;
            rollTime = 0.5f;
            canRoll = true;
        }
        if (isRoll == true)
        {
            this.rollTime -= Time.deltaTime;
            if (rollTime <= 0)
            {
                this.bossMovement.SetMoveSpeed(1f);
                this.moveSpeed = 1f;
                isRoll = false;
                canRoll = false;
                this.bossDamageSender.ResetDamageSkill();
                
                animator.SetBool("Roll", false);
            }
        }
   
    }
    public virtual bool IsRoll()
    {
        return isRoll;
    }
  

}
