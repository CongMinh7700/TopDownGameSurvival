using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : GameMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner; 
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => spawnPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + "||LoadSpawner||", gameObject);
    } 
    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = GameObject.Find("SceneSpawnPoint").GetComponent<SpawnPoint>();
        Debug.Log(transform.name + "||LoadSpawnPoint||", gameObject);
    }
}
