using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGlowController : MonoBehaviour
{
    public Transform targetCamera; // The camera to follow
    public float speed = 300000000.0f; // The speed at which to follow the camera
    public float pos_y;//transform.position.y + 10f;

    private void FixedUpdate()
    {
        // Get the target position (x and y) of the camera
        //Vector3 targetPos = new Vector3(targetCamera.position.x , transform.position.y, targetCamera.position.z);

        // Move towards the target position at the specified speed
        //transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        transform.position = new Vector3(targetCamera.position.x , 17f , targetCamera.position.z + 25f);
    }
}
