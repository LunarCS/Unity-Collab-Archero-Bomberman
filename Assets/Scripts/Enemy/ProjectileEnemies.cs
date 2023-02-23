using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemies : Enemy
{
    public bool canRicochet;
    public int maxRicochets;
    public Collider2D enemyCollider;


    private void Start()
    {
        InvokeRepeating(nameof(ShootProjectile), 1f, abilityRate);
        
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(abilityPrefab, transform.position, Quaternion.identity);
        Projectile projectileClass = projectile.GetComponent<Projectile>();
        Collider2D projectileCollider = projectileClass.selfCollider;
        Physics2D.IgnoreCollision(projectileCollider, enemyCollider);
        projectileClass.Ricochet(canRicochet, maxRicochets);
        projectileClass.velocity *= (int)transform.localScale.x;
    }
}
