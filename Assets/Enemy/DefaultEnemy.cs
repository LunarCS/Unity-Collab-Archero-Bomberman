using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{

    private void Start()
    {
        InvokeRepeating(nameof(DropBomb), 2f, abilityRate);
    }
    private void DropBomb()
    {
        GameObject bomb = Instantiate(abilityPrefab, transform.position, Quaternion.identity);
        Destroy(bomb, 1f);
    }
}
