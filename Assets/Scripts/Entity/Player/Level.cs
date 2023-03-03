using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private static Level instance;
    public static Level Instance { get { return instance; } }
    public int CurrentLevel { get; set; }

    [SerializeField] LoadUpgrade upgradeManager;
    public int XP { get; set; }
    private int xpToLevelUp;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;

    }

    private void Start()
    {
        CurrentLevel = 1;
        XP = 0;
    }

    private void Update()
    {
    }

    public void GainXP(int xpGained)
    {
        XP += xpGained;
        xpToLevelUp -= xpGained;
    }

    private void LevelUp()
    {
        if(++CurrentLevel % 2 == 0)
        {
            upgradeManager.gameObject.SetActive(true);
        };
        XP = -xpToLevelUp;
        
    }
}
