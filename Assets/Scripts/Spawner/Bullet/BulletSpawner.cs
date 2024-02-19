using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public  string bulletOne = "Bullet_1";
    public  string bulletTwo = "Bullet_2";

    protected override void Awake()
    {
        if (BulletSpawner.instance != null) Debug.LogWarning("Only 1 BulletSpawner allow to exist");
        BulletSpawner.instance = this;

    }
}
