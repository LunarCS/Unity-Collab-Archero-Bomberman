using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : EnemyMovement
{
    public float hp;
    public float damage;
    public GameObject abilityPrefab;
    public float abilityRate;

}