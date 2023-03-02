using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : Player
{
    private static Upgrade s_uinstance;
    public static Upgrade UInstance { get { return s_uinstance; } }
    public int upgradeID;
    public int maxBombsUpgrade;
    public float fuseTimerUpgrade;  
    public bool isDoubleBomb;
    public int healthUpgrade;
    public int armourUpgrade;
    public int speedUpgrade;
    public bool isRicochet;

    private void Awake()
    {
        if (s_uinstance != null)
            Destroy(gameObject);
        s_uinstance = this;
    }


    [ContextMenu("Health")]
    public void HealthUpgrade() // Multiply hp
    {
        MaxHealth = Mathf.FloorToInt(MaxHealth * healthUpgrade);
    }
    [ContextMenu("Speed")]
    public void SpeedUpgrade()      // Multiply movespeed
    {
        MoveSpeed = Mathf.FloorToInt(MoveSpeed * speedUpgrade);
    }
    [ContextMenu("MaxBomb")]
    public void MaxBombUpgrade()    // add an n amount of max bombs
    {
        GameController.Instance.MaxBombs += maxBombsUpgrade;
    }
    [ContextMenu("Double")]
    public void DoubleBombUpgrade()
    {
        DoubleBomb = isDoubleBomb;
    }
    [ContextMenu("Fuse")]
    public void FuseTimerUpgrade()
    {
        FuseTimer -= fuseTimerUpgrade;
    }
    [ContextMenu("Do Something")]
    public void RicochetUpgrade()
    {

    }



}
