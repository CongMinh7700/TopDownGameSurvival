using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtMouse : ObjectLookAtTarget
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.targetPosition = InputManager.Instance.MouseWorlPos;
        this.targetPosition.z = 0;  
    }
}
