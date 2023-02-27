using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    const int HEALTH_UPGRADE = 1;
    const int SPEED_UPGRADE = 2;
    const int MAX_BOMBS_UPGRADE = 3;
    const int DOUBLE_BOMB_UPGRADE = 4;
    const int FUSE_UPGRADE = 5;
    const int DEFENCE_UPGRADE = 6;

    Color HEALTH_COLOR = new(208 / 255f, 0f, 50 / 255f);
    Color SPEED_COLOR = new Color(79 / 255f, 221 / 255f, 255 / 255f);
    Color FUSE_TIME_COLOR = new Color(255 / 255f, 207 / 255f, 19 / 255f);
    Color DOUBLE_BOMB_COLOR = new Color(38 / 255f, 38 / 255f, 38 / 255f);
    Color MAX_BOMB_COLOR = new Color(248 / 255f, 126 / 255f, 7 / 255f);
    Color DEFENCE_COLOR = new Color(195 / 255f, 0f, 208 / 255f);
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
    }

    public void OnClick()
    {
        //icon.color = HEALTH_COLOR;
    }
}
