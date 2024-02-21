using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelForHP: LevelDouble 
{
    [Header("Level For HP")]
    public EnemyDamageReceiver enemyDamageReceiver;
    protected override void ResetValue()
    {
        base.ResetValue();
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
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = transform.parent.GetComponent<EnemyDamageReceiver>();
        Debug.LogWarning(transform.name + "||LoadDamageReceiver||", gameObject);
    }
    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.CurrentLevel;
        this.SetLevel(level);
        this.enemyDamageReceiver.SetHpMax(this.number);
        this.enemyDamageReceiver.Reborn();
    }

}
