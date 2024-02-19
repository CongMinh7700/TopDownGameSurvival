using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : ShootableObjectDamageReceiver
{
    public override void OnDead()
    {
        base.OnDead();      
        GameManager.Instance.UpdateScore(10);
     
    }
   
}
