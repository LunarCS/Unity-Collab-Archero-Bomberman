using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; } }
    [SerializeField] float moveSpeed;
    public Rigidbody2D rb;
    public GameObject bombPrefab;
    [SerializeField] Joystick joystick;
    private Vector2 moveDirection;
    private Camera cam;
    

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        cam = Camera.main;
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
        CombatInput();



    }

    void MovementInput()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;
        moveDirection = new Vector2(moveX, moveY);
    }

    void CombatInput()
    { 
    }

    public void DropBomb()
    {
        if (GameController.Instance.activeBombs >= GameController.Instance.maxBombs)
        {
            return;
        }
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Destroy(bomb, 1f);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.fixedDeltaTime, moveDirection.y * moveSpeed * Time.fixedDeltaTime);
    }
}
