using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : GameMonoBehaviour
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    public SpawnerCtrl SpawnerCtrl => spawnerCtrl;

    [SerializeField] protected float randDelay = 1f;
    [SerializeField] protected float randTimer = 0f;
    [SerializeField] protected int randLimit = 9;
    [Header("EffectSpawn")]
    [SerializeField] protected float timeDelay = 0f;

    [SerializeField] protected Transform appearX;
    [SerializeField] protected bool isEFRunning = false;
    [SerializeField] protected bool canSpawn = false;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
        this.LoadAppearX();
    }
    protected virtual void LoadAppearX()
    {
        if (this.appearX != null) return;
        this.appearX = Resources.Load<Transform>("Prefabs/AppearEffect");
        Debug.LogWarning(transform.name + "||LoadAppearX||", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    private void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + "||LoadSpawnerCtrl||", gameObject);
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
            yield return new WaitForSeconds(1.25f);
            Transform obj = spawnerCtrl.Spawner.Spawn(prefabName, position, rotation);
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
    protected virtual bool ReachLimit()
    {
        int current = spawnerCtrl.Spawner.SpawnedCount;
        return current >= randLimit;
    }

}
