using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlyMovement : EnemyMovement
{
    protected override void ResetValue()
    {
        this.moveSpeed = 0.75f;
    }
}


