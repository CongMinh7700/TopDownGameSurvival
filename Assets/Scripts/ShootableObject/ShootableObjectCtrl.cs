using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : GameMonoBehaviour
{

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected Spawner spawner;
    public  Spawner Spawner => spawner; 
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
        this.LoadModel();
        this.LoadSpawner();
        this.LoadSO();
        this.LoadDamageReceiver();

    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + "||LoadDespawn||", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + "||LoadModel||", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponentInChildren<Spawner>();
        Debug.Log(transform.name + "||LoadSpawner||", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + "||LoadDamageReceiver||", gameObject);
    }
    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = this.GetObjectTypeString() + "/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + "||LoadSO||"+ resPath, gameObject);
    }
    protected abstract string GetObjectTypeString();

}
