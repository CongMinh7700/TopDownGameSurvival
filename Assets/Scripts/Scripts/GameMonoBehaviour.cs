using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {

    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }  
  
    protected virtual void OnEnable()
    {

    }
    protected virtual void OnDisable()
    {

    }
    protected virtual void LoadComponents()
    {

    }
    protected virtual void ResetValue()
    {

    }
}
