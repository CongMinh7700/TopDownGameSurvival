using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelForDamageEnemy : LevelDouble
{
    [Header("LevelForDamage")]
    [SerializeField] protected EnemyDamageSender enemyDamageSender;

    protected override void ResetValue()
    {
        this.baseNumber = 2;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.UpdateLevel();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDamageSender();
    }
    protected virtual void LoadEnemyDamageSender()
    {
        if (this.enemyDamageSender != null) return;
        this.enemyDamageSender = transform.parent.GetComponent<EnemyDamageSender>();
    }
    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.CurrentLevel ;
        this.SetLevel(level);
        this.enemyDamageSender.SetMaxDamage(this.number);

    }

}
