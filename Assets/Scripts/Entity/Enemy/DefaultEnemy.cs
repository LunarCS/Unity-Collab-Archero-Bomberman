using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{

    private void Start()
    {
        InvokeRepeating(nameof(DropBomb), 2f, abilityRate);
    }

    protected override void DropBomb()
    {
        GameObject bomb = Instantiate(_bombPrefab, transform.position, transform.rotation);
        Bomb bombClass = bomb.GetComponent<Bomb>();
        bombClass.DoubleBomb = DoubleBomb;
        bombClass.FuseTimer = FuseTimer;
        Destroy(bomb, FuseTimer);
    }
}
