using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarSpawner : Spawner
{
    private static HpBarSpawner instance;
    public static HpBarSpawner Instance =>instance;
    public static string HpBar = "HpBar";

    protected override void Awake()
    {
        if (HpBarSpawner.instance != null) Debug.LogWarning("Only 1 HpBarSpawner allow to exist");
        HpBarSpawner.instance = this;
    }
}
