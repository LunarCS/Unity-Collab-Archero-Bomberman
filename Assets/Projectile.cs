using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Rigidbody2D rb;
    public int velocity;

    private void Start()
    {
        rb.AddForce(transform.right * velocity, ForceMode2D.Impulse);
    }
}
