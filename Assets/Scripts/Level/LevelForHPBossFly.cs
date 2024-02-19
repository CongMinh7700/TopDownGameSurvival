using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelForHPBossFly : LevelForHPBoss
{
  
    protected override void ResetValue()
    {
        this.baseNumber = 50;
    }
    
}
