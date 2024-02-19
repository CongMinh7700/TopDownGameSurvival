using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : Singleton<MapCtrl>
{
    [SerializeField] protected MapLevel mapLevel;
    public MapLevel MapLevel => mapLevel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMapLevel();
    }
    protected virtual void LoadMapLevel()
    {
        if (this.mapLevel != null) return;
        this.mapLevel = GetComponentInChildren<MapLevel>();
        Debug.LogWarning(transform.name + "||LoadMapLevel||", gameObject);
    }
}
