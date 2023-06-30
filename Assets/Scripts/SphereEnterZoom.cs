using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SphereEnterZoom : MonoBehaviour
{
    [SerializeField] DestinationManager dest;
    [SerializeField] CanvasManager canMan;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float zoomAmount = 5f;
    [SerializeField] private Camera mainCamera;
    private Vector3 startPosition; // The starting position for the camera
    private Vector3 endPosition; // The destination position for the camera
    private float speed; // The speed at which the camera moves
    private float startTime; // The time at which the movement starts
    public bool isMoving = false;
    public bool entered = false;
    public GameObject testPanel;
    public GameObject FireVideo;
    public UnityEvent ActivateDestination;
    public UnityEvent DeactivateDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            entered = true;
            Debug.Log("main camera enter detected");
            MoveCamera(new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y,mainCamera.transform.position.z), gameObject.transform.position, moveSpeed);
            canMan.PopulateBoxes(dest);
        }
    }
    void Update()
    
    {
        
        // if (entered)
        // {
        //     Debug.Log("entered is true");
        //     // MoveCamera(new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y,mainCamera.transform.position.z), destinationLoc, 1.5f);
        //
        // }

        if (isMoving)
        {   
            Debug.Log("is moving triggered");
            Debug.Log("start pos is " + startPosition);
            Debug.Log("End Pos is " + endPosition);
            float journeyLength = Vector3.Distance(startPosition, endPosition);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

            if (fracJourney >= 1f)
            {
                if (entered)
                {
                    //testPanel.SetActive(true);
                    FireVideo.SetActive(true);
                    ActivateDestination.Invoke();
                }
                isMoving = false;
            }
        }
    }
  
    public void MoveCamera(Vector3 start, Vector3 end, float speed)
    {
        Debug.Log("moveCam triggered");
        this.startPosition = start;
        this.endPosition = end;
        this.speed = speed;
        this.startTime = Time.time;
        isMoving = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            entered = false;
            //testPanel.SetActive(false);
            FireVideo.SetActive(false);
            DeactivateDestination.Invoke();
            Debug.Log("camera exit detected");
            //MoveCamera(new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y,mainCamera.transform.position.z), new Vector3(mainCamera.transform.position.x,(mainCamera.transform.position.y + 8f), (mainCamera.transform.position.z - 5f)), moveSpeed);
        }
    }
}
