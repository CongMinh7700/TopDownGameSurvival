using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        //base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    //Load prefabs thi khong can load in children
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }
        this.HidePrefabs();

    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");


    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
       
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found");
            return null;
        }

        return Spawn(prefab, position, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
       
        // Debug.LogWarning("Spawning enemy from " + this.GetType().Name);
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, rotation);

        newPrefab.SetParent(this.holder);
        newPrefab.gameObject.SetActive(true);

        spawnedCount++;
        return newPrefab;

    }
    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;

    }
    public virtual void Despawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;
        obj.gameObject.SetActive(false);
        this.poolObjs.Add(obj);
        // obj.SetParent(null);
        this.spawnedCount--;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        //Moi them

        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj == null) continue;
            if (poolObj.name == prefab.name && !poolObj.gameObject.activeSelf)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }

        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual Transform GetRandomPrefabs()
    {
        int rand = Random.Range(0, prefabs.Count);
        return this.prefabs[rand];
    }
}
