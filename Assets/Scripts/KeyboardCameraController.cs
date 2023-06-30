using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    public float dampening = 2;
    
    private Vector3 velocity;
    private Vector3 velocityTarget;
    
    private void Update()
    {
        
        /*if (transform.position.y<=6)
        {
            Quaternion target = Quaternion.Euler(0, 0, 0);


            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 5.0f);
        }
        else
        {
            Quaternion target = Quaternion.Euler(30, 0, 0);


            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 5.0f);
        }*/

        velocityTarget = Vector3.zero;

        // Check for left arrow key
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            velocityTarget += (Vector3.left * movementSpeed * Time.deltaTime);
        }

        // Check for right arrow key
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            velocityTarget += (Vector3.right * movementSpeed * Time.deltaTime);
        }
        // Check for up arrow key
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
            velocityTarget += (Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // Check for down arrow key
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += Vector3.back * movementSpeed * Time.deltaTime;
            velocityTarget += (Vector3.back * movementSpeed * Time.deltaTime);
        }
        
        velocity = Vector3.Lerp(velocity, velocityTarget, Time.deltaTime * dampening);
        transform.position += velocity;

    }
}
