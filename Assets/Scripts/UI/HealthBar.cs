using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : GameMonoBehaviour
{
   
   
    [SerializeField] protected Image fillBar;
    [SerializeField] protected TextMeshProUGUI hpText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHpText();
        this.LoadFillBar();
      
    }
    protected virtual void LoadFillBar()
    {
        if (this.fillBar != null) return;
        this.fillBar = transform.Find("FillBar").GetComponent<Image>();
        Debug.LogWarning(transform.name + "||LoadFillBar||", gameObject);
    }
    protected virtual void LoadHpText()
    {
        if (this.hpText != null) return;
        this.hpText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "||LoadHpText||", gameObject);
    }
    protected virtual void SetHpUI(double currentHp, double maxHp)
    {
        this.fillBar.fillAmount = (float)currentHp / (float)maxHp;
       // this.hpText.text = currentHp.ToString() + "/" + maxHp.ToString();
    }
    

}
