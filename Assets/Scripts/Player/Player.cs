using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; } }

    public Rigidbody2D rb;
    public GameObject bombPrefab;
    private int currentHealth;

    [SerializeField] Joystick joystick;
    private Vector2 moveDirection;
    private Camera cam;

    [Header("Stats")]
    public float fuseTimer;
    public bool ricochetBomb;
    public float moveSpeed;
    public bool doubleBomb;
    public int maxHealth;



    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

    }
    private void Start()
    {
        cam = Camera.main;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        MovementInput();
    }

    void MovementInput()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;
        moveDirection = new Vector2(moveX, moveY);
    }

    public void DropBomb()
    {
        Attacks.Instance.DropBomb(transform.position, transform.rotation, fuseTimer, doubleBomb);
    }


    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.fixedDeltaTime, moveDirection.y * moveSpeed * Time.fixedDeltaTime);
    }
}
