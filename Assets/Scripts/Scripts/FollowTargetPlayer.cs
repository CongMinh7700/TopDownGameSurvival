using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetPlayer : FollowTarget
{
  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Player").transform;
        //   Debug.LogWarning(transform.name + "||LoadPlayer||", gameObject);
    }
   
}
