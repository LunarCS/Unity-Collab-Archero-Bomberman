using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoadUpgrade : MonoBehaviour
{

    private static LoadUpgrade instance;
    public static LoadUpgrade Instance { get { return instance; } }

    [SerializeField] UpgradeButton[] upgradeButtons = new UpgradeButton[3];
    int[] upgradeButtonID = new int[3];

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }


    private void OnEnable()
    {
        GenerateRandomSequence(ref upgradeButtonID, 1, 7);
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].UpdateIcons(upgradeButtonID[i], ref upgradeButtons[i].icon);
        }
    }

    private void GenerateRandomSequence(ref int[] randomArr, int start, int end)
    {
        int random = Random.Range(start, end);
        for (int i = 0; i < randomArr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (randomArr[j] == random)
                {
                    random = Random.Range(start, end);
                    j = -1;
                }
            }

            if (randomArr[i] != random)
            {
                randomArr[i] = random;
            }
        }
    }








}
