using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 1f;
    private Rigidbody2D rb; // The player's Rigidbody2D component.
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Get input from the horizontal and vertical axes.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector and normalize it to ensure constant speed in all directions.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        moveVelocity = movement.normalized * moveSpeed;

        // Apply the movement vector to the player's Rigidbody2D component.
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
