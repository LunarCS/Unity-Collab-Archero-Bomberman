using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalEnemy : Enemy
{
    public ParticleSystem element;

    private void Start()
    {
        InvokeRepeating(nameof(DropElementalBomb), 10f, abilityRate);
    }

    void DropElementalBomb()
    {
        GameObject elementalBomb = Instantiate(abilityPrefab, transform.position, Quaternion.identity);
        Destroy(elementalBomb, 1f);
    }
}
