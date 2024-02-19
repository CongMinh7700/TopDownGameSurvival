using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlySkill : GameMonoBehaviour
{
    [SerializeField] protected BossFlyMovement bossFlyMovement;
    [SerializeField] protected Transform model;
    [Header("Boss Roll")]
    [SerializeField] protected float skillTime = 5f;
    [SerializeField] protected float skillDelay = 7f;
    [SerializeField] protected float speedRotation = 25f;
    [SerializeField] protected bool isUsingSkill = false;
    [SerializeField] protected bool canUseSkill = false;
    [SerializeField] protected Transform skillShooting;
    [SerializeField] protected Transform bossShooting;
    protected override void Start()
    {
        this.skillShooting.gameObject.SetActive(false);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadBossFlyMovement();
        this.LoadSkillShooting();
        this.LoadBossShooting();
    }
   
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.parent.Find("Model");

    }
    protected virtual void LoadBossFlyMovement()
    {
        if (this.bossFlyMovement != null) return;
        this.bossFlyMovement = transform.parent.GetComponentInChildren<BossFlyMovement>();
    }
    protected virtual void LoadSkillShooting()
    {
        if (this.skillShooting != null) return;
        this.skillShooting = transform.Find("SkillShooting");
        Debug.LogWarning(transform.name + "||LoadSkillShooting||", gameObject);
    } 
    protected virtual void LoadBossShooting()
    {
        if (this.bossShooting != null) return;
        this.bossShooting = transform.parent.Find("BossShooting");
        Debug.LogWarning(transform.name + "||LoadBossShooting||", gameObject);
    } 
  

    protected virtual void Update()
    {
        this.UsingSkill();
    }
    protected virtual void UsingSkill()
    {
        if (this.canUseSkill)
        {
            isUsingSkill = true;
            this.skillDelay = 5f;
            this.bossFlyMovement.gameObject.SetActive(false);
            this.bossShooting.gameObject.SetActive(false);
            this.skillShooting.gameObject.SetActive(true);
            this.SkillShootingRotation();
        }
        this.RollCoolDown();
    }
    protected virtual void SkillShootingRotation()
    {
        this.skillShooting.Rotate(0.0f, 0.0f, speedRotation * Time.deltaTime);
    }
    protected virtual void RollCoolDown()
    {
        skillDelay -= Time.deltaTime;
        if (skillDelay <= 0)
        {
            skillDelay = 0;
            skillTime = 5f;
            canUseSkill = true;
        }
        if (isUsingSkill == true)
        {
            this.skillTime -= Time.deltaTime;
            if (skillTime <= 0)
            {
                this.bossFlyMovement.gameObject.SetActive(true);
                this.bossShooting.gameObject.SetActive(true);
                this.skillShooting.gameObject.SetActive(false);
                isUsingSkill = false;
                canUseSkill = false;
            }
        }

    }


}
