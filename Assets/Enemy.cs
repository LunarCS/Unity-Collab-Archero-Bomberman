using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const int X_AXIS = 0;
    const int Y_AXIS = 1;
    public int currentAxis;

    public int maxHealth = 100;
    public Rigidbody2D rb;
    private int currentHealth;

    private Vector2 startingPostion;
    private float moveRadius = 10f;
    private int moveSpeed = 3;

    private void Start()
    {
        currentHealth = maxHealth;
        startingPostion = transform.position;
    }

    private void Update()
    {
        if (transform.position.sqrMagnitude >= Mathf.Pow(moveRadius, 2))
        {
            FaceOpposite(currentAxis);
            currentAxis *= -1;
        }
        
    }

    private void FixedUpdate()
    {
        Move(currentAxis);
    }

    void Move(int axis)
    {
        switch (axis)
        {
            case X_AXIS:
                rb.velocity = transform.up * moveSpeed;
                break;
            case Y_AXIS:
                rb.velocity = transform.right * moveSpeed;
                break;
        }
    }

    void FaceOpposite(int axis)
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * -1);
        Move(-axis);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FaceOpposite(currentAxis);
    }
}
