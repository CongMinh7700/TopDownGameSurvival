using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelForHPBoss : LevelDouble
{
    [Header("LevelForBoss")]
    [SerializeField] protected BossDamageReceiver bossDamageReceiver;
    [SerializeField] protected int levelOffset = 3;

    protected override void ResetValue()
    {
        this.baseNumber = 100;
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
        if (this.bossDamageReceiver != null) return;
        this.bossDamageReceiver = transform.parent.GetComponent<BossDamageReceiver>();
    }
    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.CurrentLevel + this.levelOffset;
        this.SetLevel(level);
        this.bossDamageReceiver.SetHpMax(this.number);
        this.bossDamageReceiver.SetCurrentHp(this.number);

    }
}
