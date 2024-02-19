using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossRandom : GameMonoBehaviour
{

    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    public SpawnerCtrl SpawnerCtrl => spawnerCtrl;

    [SerializeField] protected float randDelay = 1f;
    [SerializeField] protected float randTimer = 0f;
    [SerializeField] protected int randLimit = 1;
    [Header("EffectSpawn")]
    [SerializeField] protected float timeDelay = 0f;

    [SerializeField] protected Transform appearX;
    [SerializeField] protected bool isEFRunning = false;
    [SerializeField] protected bool canSpawn = false;

    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected bool canSpawnBoss;



    protected static SpawnBossRandom instance;
    public static SpawnBossRandom Instance => instance;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
        this.LoadAppearX();
        this.LoadGameManager();
    }
    protected virtual void LoadAppearX()
    {
        if (this.appearX != null) return;
        this.appearX = Resources.Load<Transform>("Prefabs/AppearEffect");
        Debug.LogWarning(transform.name + "||LoadAppearX||", gameObject);
    }
    protected virtual void LoadGameManager()
    {
        if (this.gameManager != null) return;
        this.gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Debug.LogWarning(transform.name + "||LoadGameManager||", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        canSpawnBoss = gameManager.CanSpawnBoss();
        if (!canSpawnBoss) return;
        this.Spawning();

    }
    private void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + "||LoadSpawnerCtrl||", gameObject);
    }
    protected virtual bool ReachLimit()
    {
        int current = this.spawnerCtrl.Spawner.SpawnedCount;
        return current >= this.randLimit;
    }
    protected virtual void Spawning()
    {
        if (ReachLimit())
        {
            return;
        }
        randTimer += Time.deltaTime;
        if (randTimer < randDelay) return;
        randTimer = 0;
        Transform prefab = spawnerCtrl.Spawner.GetRandomPrefabs();
        Transform point = spawnerCtrl.SpawnPoint.GetRandomPoint();
        Vector3 position = point.position;
        Quaternion rotation = point.rotation;
        StartCoroutine(SpawnEnemyAfterEffect(prefab.name, position, rotation));
        StartCoroutine(SpawnEffect(position, rotation));
    

    }
    protected virtual IEnumerator SpawnEnemyAfterEffect(string prefabName, Vector3 position, Quaternion rotation)
    {
        
        if (this.canSpawn)
        {
           
            Transform obj = spawnerCtrl.Spawner.Spawn(prefabName, position, rotation);
            yield return new WaitForSeconds(1.25f);
            obj.gameObject.SetActive(true);
            this.isEFRunning = false;
          
        }
    }
    protected virtual IEnumerator SpawnEffect(Vector3 position, Quaternion rotation)
    {

        if (!this.isEFRunning)
        {
            this.isEFRunning = true;
            this.canSpawn = false;
            Transform appear = Instantiate(appearX, position, rotation);
            yield return new WaitForSeconds(1f);
            this.canSpawn = true;
            Destroy(appear.gameObject);

        }

    }
    

}
