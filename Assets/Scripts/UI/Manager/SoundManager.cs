using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : GameMonoBehaviour
{
    [SerializeField] protected Slider volumeSlider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVolumeSlider();
    }

    protected virtual void LoadVolumeSlider()
    {
        if (this.volumeSlider != null) return;
        this.volumeSlider = GetComponentInChildren<Slider>();
        Debug.LogWarning(transform.name + "||LoadVolumeSlider||", gameObject);
    }
    public virtual void SetVolume()
    {
        float volume = volumeSlider.value;
    }
}
