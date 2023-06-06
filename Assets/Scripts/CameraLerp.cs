using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    private Vector3 startPosition; // The starting position for the camera
    private Vector3 endPosition; // The destination position for the camera
    private float speed; // The speed at which the camera moves
    private float startTime; // The time at which the movement starts

    void Update()
    
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            MoveCamera(new Vector3(transform.position.x,transform.position.y,transform.position.z), new Vector3(10, 0, 0), 1.5f);

        }

        if (isMoving)
        {
            float journeyLength = Vector3.Distance(startPosition, endPosition);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

            if (fracJourney >= 1f)
            {
                isMoving = false;
            }
        }
    }

    private bool isMoving = false;
    
    
    public void MoveCamera(Vector3 start, Vector3 end, float speed)
    {
        this.startPosition = start;
        this.endPosition = end;
        this.speed = speed;
        this.startTime = Time.time;
        isMoving = true;
    }
    
    // Start is called before the first frame update

    void Start()
    {
    }

}
