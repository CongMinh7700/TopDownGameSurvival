using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHp : BaseSlider
{
    [Header("Slider Hp")]
    [SerializeField] protected double maxHp = 100;
    [SerializeField] protected double currentHp  = 70;

    protected virtual void FixedUpdate()
    {
        this.HpShowing();
    }

    protected virtual void HpShowing()
    {
        double hpPercent = this.currentHp / this.maxHp;
        this.slider.value = (float)hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
    
    }
    public virtual void SetHpMax(double maxHp)
    {
        this.maxHp = maxHp;
    }  
    public virtual void SetCurrentHp(double currentHP)
    {
        this.currentHp = currentHP;
    }
}
