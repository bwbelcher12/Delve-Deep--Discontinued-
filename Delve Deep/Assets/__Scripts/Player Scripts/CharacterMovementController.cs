using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    Rigidbody body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    private GameManager gm;

    public float runSpeed = 5.0f;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gm.gameOver || gm.isPaused)
        {
            horizontal = 0;
            vertical = 0;
            return;
        }

        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {


        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector3(horizontal * runSpeed, 0, vertical * runSpeed);

    }
}
