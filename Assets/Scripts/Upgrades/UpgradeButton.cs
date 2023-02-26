using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    const int HEALTH_UPGRADE = 0;
    const int SPEED_UPGRADE = 1;
    const int MAX_BOMBS_UPGRADE = 2;
    const int DOUBLE_BOMB_UPGRADE = 3;
    const int FUSE_UPGRADE = 4;
    const int DEFENCE_UPGRADE = 5;

    Color HEALTH_COLOR = new Color(208, 0, 50);
    Color SPEED_COLOR = new Color(79, 221, 255);
    Color FUSE_TIME_COLOR = new Color(255, 207, 19);
    Color DOUBLE_BOMB_COLOR = new Color(38, 38, 38);
    Color MAX_BOMB_COLOR = new Color(248, 126, 7);
    Color DEFENCE_COLOR = new Color(195, 0, 208);

    public Image icon;

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
            case DEFENCE_UPGRADE:
                break;
        }
    }

    public void UpdateIcons(int id, ref Image icon)
    {
        switch (id)
        {
            case HEALTH_UPGRADE:
                icon.color = HEALTH_COLOR;
                break;
            case SPEED_UPGRADE:
                icon.color = SPEED_COLOR;
                break;
            case MAX_BOMBS_UPGRADE:
                icon.color = MAX_BOMB_COLOR;
                break;
            case DOUBLE_BOMB_UPGRADE:
                icon.color = DOUBLE_BOMB_COLOR;
                break;
            case FUSE_UPGRADE:
                icon.color = FUSE_TIME_COLOR;
                break;
            case DEFENCE_UPGRADE:
                icon.color = DEFENCE_COLOR;
                break;
        }
        icon.color = HEALTH_COLOR;
    }
}
