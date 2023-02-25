using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUpgrade : MonoBehaviour
{
    const int HEALTH_UPGRADE = 0;
    const int SPEED_UPGRADE = 1;
    const int MAX_BOMBS_UPGRADE = 2;
    const int DOUBLE_BOMB_UPGRADE = 3;
    const int FUSE_UPGRADE = 4;
    const int RICOCHET_UPGRADE = 5;



    int[] upgradeIndexes;
    int upgradeCount;
    GameObject[] upgradeButtons = new GameObject[3];
    int[] upgradeButtonID = new int[3];
    List<int> upgradeIDS = new List<int>();

    private void Start()
    {
        upgradeCount = upgradeIDS.Count;
        upgradeIndexes = new int[upgradeCount];
    }

    private void OnEnable()
    {

    }

    public void UpdateIcons(int id, ref Image[] icons)
    {
        switch (id)
        {
            case HEALTH_UPGRADE:
                Upgrade.Instance.HealthUpgrade();
                break;
            case SPEED_UPGRADE:
                Upgrade.Instance.SpeedUpgrade();
                break;
            case MAX_BOMBS_UPGRADE:
                Upgrade.Instance.MaxBombUpgrade();
                break;
            case DOUBLE_BOMB_UPGRADE:
                Upgrade.Instance.DoubleBombUpgrade();
                break;
            case FUSE_UPGRADE:
                Upgrade.Instance.FuseTimerUpgrade();
                break;
            case RICOCHET_UPGRADE:
                break;
        }
    }
    public void GetUpgradeChoice(int id, ref Image[] icons)
    {
        switch (id)
        {
            case HEALTH_UPGRADE:
                Upgrade.Instance.HealthUpgrade();
                break;
            case SPEED_UPGRADE:
                Upgrade.Instance.SpeedUpgrade();
                break;
            case MAX_BOMBS_UPGRADE:
                Upgrade.Instance.MaxBombUpgrade();
                break;
            case DOUBLE_BOMB_UPGRADE:
                Upgrade.Instance.DoubleBombUpgrade();
                break;
            case FUSE_UPGRADE:
                Upgrade.Instance.FuseTimerUpgrade();
                break;
            case RICOCHET_UPGRADE:
                break;
        }
    }








}
