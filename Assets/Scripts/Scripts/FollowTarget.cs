using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : GameMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

 
    protected virtual void FixedUpdate()
    {
        this.Following();
    }
    protected virtual void Following()
    {
        if (this.target == null) return;
        Vector3 smoothMove = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * speed);
        transform.position = smoothMove;
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
