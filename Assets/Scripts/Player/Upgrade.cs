using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private static Upgrade instance;
    public static Upgrade Instance { get { return instance; } }
    public int upgradeID;
    public int maxBombsUpgrade;
    public float fuseTimerUpgrade;  
    public bool isDoubleBomb;
    public int healthUpgrade;
    public int armourUpgrade;
    public int speedUpgrade;
    public bool isRicochet;

    private void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }


    [ContextMenu("Health")]
    public void HealthUpgrade() // Multiply hp
    {
        Player.Instance.maxHealth = Mathf.FloorToInt(Player.Instance.maxHealth * healthUpgrade);
    }
    [ContextMenu("Speed")]
    public void SpeedUpgrade()      // Multiply movespeed
    {
        Player.Instance.moveSpeed = Mathf.FloorToInt(Player.Instance.maxHealth * speedUpgrade);
    }
    [ContextMenu("MaxBomb")]
    public void MaxBombUpgrade()    // add an n amount of max bombs
    {
        GameController.Instance.maxBombs += maxBombsUpgrade;
    }
    [ContextMenu("Double")]
    public void DoubleBombUpgrade()
    {
        Player.Instance.doubleBomb = isDoubleBomb;
    }
    [ContextMenu("Fuse")]
    public void FuseTimerUpgrade()
    {
        Player.Instance.fuseTimer -= fuseTimerUpgrade;
    }
    [ContextMenu("Do Something")]
    public void RicochetUpgrade()
    {

    }



}
