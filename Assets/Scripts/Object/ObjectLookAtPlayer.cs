using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtPlayer : ObjectLookAtTarget
{
    [Header("Look At Player")]
    [SerializeField] protected Transform player;
    [SerializeField] protected Transform model;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadModel();
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(transform.name + "||LoadPlayer||", gameObject);
    } 
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.parent?.Find("Model");
        Debug.LogWarning(transform.name + "||LoadModel||", gameObject);
    }

    protected virtual void GetPlayerPosition()
    {
        if (this.player == null) return;
        this.targetPosition = this.player.position;
        this.targetPosition.z = 0;
    }
    protected override void LookAtTarget()
    {
        Vector3 diff = player.position - transform.parent.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;

        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
        model.rotation = Quaternion.identity;
    }
}
