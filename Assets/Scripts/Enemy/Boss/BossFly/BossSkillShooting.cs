using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillShooting : ObjectShootingByDistance
{
    protected override void ResetValue()
    {
        this.shootDelay = 0.25f;
    }
}
