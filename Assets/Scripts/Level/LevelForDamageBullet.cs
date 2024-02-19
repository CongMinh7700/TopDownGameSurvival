using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelForDamageBullet : LevelDouble
{
    [Header("LevelForDamage")]
    [SerializeField] protected BulletDamageSender bulletDamageSender;

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
        this.LoadBulletDamageSender();
    }
    protected virtual void LoadBulletDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.parent.GetComponent<BulletDamageSender>();
    }
    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.CurrentLevel ;
        this.SetLevel(level);
        this.bulletDamageSender.SetMaxDamage(this.number);

    }

}
