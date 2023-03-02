using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private static Player s_instance;
    public static Player Instance { get { return s_instance; } }



    [SerializeField] Joystick joystick;
    private Vector2 moveDirection;
    private Camera cam;





    void Awake()
    {
        if (s_instance != null)
        {
            Destroy(gameObject);
        }
        s_instance = this;
        

    }
    private void Start()
    {
        cam = Camera.main;
        MoveSpeed = 250;
        FuseTimer = 3;
        CurrentHealth = MaxHealth;
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

    protected override void Move()
    {
        _rb.velocity = new Vector2(moveDirection.x * MoveSpeed * Time.deltaTime, moveDirection.y * MoveSpeed * Time.deltaTime);
    }

    public void DropBombButton()
    {
        DropBomb();
    }
    protected override void DropBomb()
    {
        Attacks.Instance.DropBomb(transform.position, transform.rotation, FuseTimer, DoubleBomb);
    }



}
