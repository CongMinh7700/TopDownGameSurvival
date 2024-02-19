using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawner : Spawner
{
    protected static FxSpawner instance;
    public static FxSpawner Instance =>instance;

    public static string textDamage = "TextDamage";
    public static string smoke_1 = "Smoke_1";
    public static string hurtSound = "HurtSound";
    protected override void Awake()
    {
        base.Awake();
        if (FxSpawner.instance != null) Debug.LogWarning("Onlly 1 FxSpawner allow to exist");
        FxSpawner.instance = this;
    }
}
