using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private static Level instance;
    public static Level Instance { get { return instance; } }

    [HideInInspector]
    public int level;

    public int xp;
    private int xpToLevelUp;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;

    }

    private void Start()
    {
        level = 1;
        xp = 0;
    }

    private void Update()
    {
        if (xpToLevelUp <= 0)
        {
            LevelUp();
        }
    }

    public void GainXP(int xpGained)
    {
        xp += xpGained;
        xpToLevelUp -= xpGained;
    }

    private void LevelUp()
    {
        level++;
        xp = -xpToLevelUp;
        
    }
}
