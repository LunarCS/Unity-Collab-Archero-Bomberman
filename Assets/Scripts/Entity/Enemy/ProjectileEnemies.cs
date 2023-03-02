using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemies : Enemy
{


    private void Start()
    {
        InvokeRepeating(nameof(ShootProjectile), 1f, abilityRate);
        
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(abilityPrefab, transform.position, Quaternion.identity);
        Projectile projectileClass = projectile.GetComponent<Projectile>();
        projectileClass.Ricochet(CanRicochet, MaxRicochets);
        projectileClass.velocity *= (int)transform.localScale.x;
    }

}
