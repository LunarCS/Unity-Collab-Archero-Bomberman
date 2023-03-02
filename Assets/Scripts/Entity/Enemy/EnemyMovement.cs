using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const int X_AXIS = 1;
    const int Y_AXIS = 2;
    public int currentAxis;
    public Rigidbody2D rb;
    private Vector3 startingPostion;
    public float moveRadius = 10f;
    public int moveSpeed = 3;

    private void Start()
    {
        startingPostion = transform.position;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Bullet"));
    }

    private void Update()
    {
        if ((startingPostion - transform.position).sqrMagnitude >= Mathf.Pow(moveRadius, 2))
        {
            FaceOpposite(currentAxis, false);
        }
        
    }

    private void FixedUpdate()
    {
        Move(currentAxis, 1);
    }

    void Move(int axis, int direction)
    {
        switch (axis)
        {
            case X_AXIS:
                transform.right *= direction;
                rb.velocity = transform.right * moveSpeed;
                break;
            case Y_AXIS:
                transform.up *= direction;

                rb.velocity = transform.up * moveSpeed;
                break;
        }
    }

    void FaceOpposite(int axis, bool collided)
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * -1);
        if (!collided)
            startingPostion = transform.position;
        Move(axis, -1);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(1);
        FaceOpposite(currentAxis, true);
    }
}
