using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemies : Enemy
{
    private bool isRicochet;

    private void Start()
    {
        InvokeRepeating(nameof(ShootProjectile), 1f, abilityRate);
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(abilityPrefab, transform.position, Quaternion.identity, transform);
        projectile.GetComponent<Projectile>().velocity *= (int) transform.localScale.x;
        Destroy(projectile, 1f);
    }
}
