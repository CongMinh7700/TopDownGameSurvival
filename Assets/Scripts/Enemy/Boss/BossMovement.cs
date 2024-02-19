using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : EnemyMovement
{
    [Header("Enemy Movement")]
   
    [SerializeField] protected BossMeleeSkill bossSkill;
    Vector3 previousPlayerPosition;
    Vector2 previousPlayerDirection;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossSkill();
    }
    protected override void ResetValue()
    {
        this.moveSpeed = 1f;
    }
    protected virtual void LoadBossSkill()
    {
        if (this.bossSkill != null) return;
        this.bossSkill = transform.parent.GetComponentInChildren<BossMeleeSkill>();
        Debug.LogWarning(transform.name + "||LoadBossSkill||", gameObject);
    }
    protected override void FixedUpdate()
    {
        this.MoveToPlayer();
    }
    protected override void MoveToPlayer()
    {
        Vector2 distance = player.position - transform.position;
        Vector2 force;

        if (bossSkill.IsRoll())
        {
            force = previousPlayerDirection.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            force = distance * moveSpeed * Time.deltaTime;
            previousPlayerDirection = distance;
        }

        transform.parent.position += (Vector3)force;

        if (force.x != 0)
        {
            if (force.x < 0) transform.parent.localScale = new Vector3(-1, 1, 0);
            else transform.parent.localScale = new Vector3(1, 1, 0);
        }
    }
}


