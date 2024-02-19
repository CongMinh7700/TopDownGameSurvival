using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : Level
{
    public int bossKillCount = 0;
    protected static MapLevel instance;
    public static MapLevel Instance => instance;
    protected override void Awake()
    {
        if (MapLevel.instance != null) Debug.LogWarning("Onlly 1 Level allow to exits");
        MapLevel.instance = this;
    }
    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }
    
    protected virtual void Leveling()
    {
        bossKillCount = GameManager.Instance.BossKillCount();
        this.SetLevel(bossKillCount + 1);
    }

}
