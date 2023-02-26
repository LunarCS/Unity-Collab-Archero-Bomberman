using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoadUpgrade : MonoBehaviour
{



    [SerializeField] UpgradeButton[] upgradeButtons = new UpgradeButton[3];
    int[] upgradeButtonID = new int[3];


    private void OnEnable()
    {
        GenerateRandomSequence(ref upgradeButtonID, 0, 6);
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
                    j = 0;
                }
            }

            if (randomArr[i] != random)
            {
                randomArr[i] = random;
            }
        }
    }








}
