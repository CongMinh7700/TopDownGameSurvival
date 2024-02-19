using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelForDamageBoss : LevelDouble
{
    [Header("LevelForDamage")]
    [SerializeField] protected BossDamageSender bossDamageSender;
    [SerializeField] protected int levelOffset = 3;
    protected override void ResetValue()
    {
        this.baseNumber = 1;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.UpdateLevel();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossDamageReceiver();
    }
    protected virtual void LoadBossDamageReceiver()
    {
        if (this.bossDamageSender != null) return;
        this.bossDamageSender = transform.parent.GetComponent<BossDamageSender>();
    }
    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.CurrentLevel + this.levelOffset;
        this.SetLevel(level);
        this.bossDamageSender.SetMaxDamage(this.number);
        this.bossDamageSender.SetPreviousDamage(this.number);
    }
    
}
