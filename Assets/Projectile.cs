using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Rigidbody2D rb;
    public Collider2D selfCollider;
    public int velocity;
    private int bounces;

    private void Start()
    {
        rb.AddForce(transform.right * velocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Impassable"))
        {
            bounces--;
            if (bounces <= 0)
                Destroy(gameObject);

        }
    }

    public void Ricochet(bool canRicochet, int maxBounces)
    {
        if (canRicochet)
            bounces = maxBounces;
        else
        {
            bounces = 0;
        }

    }
}
