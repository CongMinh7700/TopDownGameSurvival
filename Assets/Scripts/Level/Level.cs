using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : GameMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int currentLevel = 0;
    [SerializeField] protected int levelMax  = 1000;

 

    public int CurrentLevel => currentLevel;
    public int LevelMax => levelMax;

  
    public virtual bool LevelUp()
    {
        int newLevel = this.currentLevel + 1;
        if (newLevel > this.levelMax) return false;

        this.currentLevel = 1;
        return true;
    }
    public virtual bool SetLevel(int newLevel)
    {
        if (newLevel > this.levelMax) return false;
        if (newLevel < 1) return false;
        this.currentLevel = newLevel;
       
        return true;
    }

}
