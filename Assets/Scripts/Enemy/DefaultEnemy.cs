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
        Attacks.Instance.DropBomb(transform.position, transform.rotation, fuseTimer, doubleBomb);
    }
}
