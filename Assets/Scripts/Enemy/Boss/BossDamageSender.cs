using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageSender : DamageSender
{

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        Vector3 hitPos = transform.position;
        this.CreateTextDamageFx(hitPos);
    }

    protected virtual string GetDamageText()
    {
        return FxSpawner.textDamage;
    }
    public virtual void CreateTextDamageFx(Vector3 hitPos)
    {
        string fxName = GetDamageText();
        Transform fxObj = FxSpawner.Instance.Spawn(fxName, hitPos, Quaternion.identity);
        TextDamage textDamage = fxObj.GetComponent<TextDamage>();
        textDamage.SetDamage(this.damage);
        fxObj.gameObject.SetActive(true);
    }
   
}
