using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    
    
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

        // Check for left arrow key
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }

        // Check for right arrow key
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        // Check for up arrow key
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
        }

        // Check for down arrow key
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;
        }
    }
}
