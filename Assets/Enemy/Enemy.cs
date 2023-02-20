using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float hp;
    private float moveSpeed;
    private float damage;
    public Enemy(float hp, float moveSpeed, float damage)
    {
        this.hp = hp;
        this.moveSpeed = moveSpeed;
        this.damage = damage;
    }

}
