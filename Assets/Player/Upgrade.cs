using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public int maxBombsUpgrade;
    public float fuseTimerUpgrade;
    public bool isDoubleBomb;
    public int healthUpgrade;
    public int armourUpgrade;
    public int speedUpgrade;
    public bool isRicochet;

    public void HealthUpgrade()
    {
        Player.Instance.maxHealth = Mathf.FloorToInt(Player.Instance.maxHealth * healthUpgrade);
    }

    public void SpeedUpgrade()
    {
        Player.Instance.moveSpeed = Mathf.FloorToInt(Player.Instance.maxHealth * speedUpgrade);
    }

    public void MaxBombUpgrade()
    {
        GameController.Instance.maxBombs += maxBombsUpgrade;
    }

    public void DoubleBomb()
    {
        Player.Instance.doubleBomb = isDoubleBomb;
    }


}
