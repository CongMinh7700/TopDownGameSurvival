using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : GameMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender => bulletDamageSender;
    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;
    [SerializeField] protected SpriteRenderer model;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamageSender();
        this.LoadSpriteRenderer();
    }
    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.LogWarning(transform.name + "||LoadBulletDespawn||", gameObject);
    }
    protected virtual void LoadSpriteRenderer()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model").GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + "||LoadSpriteRenderer||", gameObject);
        this.model.sortingOrder = 1;
    }
    protected virtual void LoadBulletDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = GetComponentInChildren<BulletDamageSender>();
        Debug.LogWarning(transform.name + "||LoadBulletDamageSender||", gameObject);
    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
    
}
