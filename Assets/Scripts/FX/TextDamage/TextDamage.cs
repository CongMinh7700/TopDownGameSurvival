using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDamage : GameMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textDamage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.textDamage != null) return;
        this.textDamage = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "||LoadText||", gameObject);
    }
    public virtual void SetDamage (double damage)
    {
        string damageNumber = LargeNumber.ToString(damage);
        this.textDamage.text = damageNumber;
    }
}
