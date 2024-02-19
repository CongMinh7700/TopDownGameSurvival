using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootingByDistance : ObjectShootingByDistance
{
    protected override void ResetValue()
    {
        this.shootDelay = 1.5f;
    }

}
