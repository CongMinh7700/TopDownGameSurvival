using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    protected Vector3 mouseWorldPos;
    public Vector3 MouseWorlPos => mouseWorldPos;

    protected float onFire;
    public float OnFire => onFire;
     void Awake()
    {
        if (InputManager.instance != null) Debug.LogWarning("Only 1 UnputManage allow to exist");
        InputManager.instance = this;
    }
    private void Update()
    {
        this.GetMouseDown();
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {    
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
    }

    protected virtual void GetMouseDown()
    {
        this.onFire = Input.GetAxis("Fire1") ;
    }


}
