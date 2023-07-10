using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;


//changes color of angel sprite in accordance with user mouse interaction
//moves the angel from left to right, and resets position based on the x value of the start and end pos objects
//triggers map and Lbox content population
//on click, triggers unity events listed in the inspector

public class ReverseAngelController : MonoBehaviour
{
    [SerializeField] CanvasManager canMan;
    [SerializeField] Transform startPos, endPos;
    [SerializeField] GameObject map;
    [SerializeField] GameObject exitButton;

    [SerializeField] float movementSpeed;
    // Update is called once per frame

    public VideoManager videoManager;
    public List<VideoClip> videos;
    public Vector3 videoOffset;
    public float videoRange = 10;

    private DestinationManager destinationManager;
    private bool withinVideoRange;
    private Vector3 clickPos = Vector3.zero;

    [SerializeField] UnityEvent AngelClick;
    [SerializeField] UnityEvent ExitAngelVideo;
    Color defaultColor;

    private void Start()
    {
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
        destinationManager = gameObject.GetComponent<DestinationManager>();
    }

    //moves angel and resets position
    void Update()
    {
        
        if(transform.position.x >= endPos.transform.position.x){
            transform.position = startPos.transform.position;
        }
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        destinationManager.videoPosAndRot.transform.position = Camera.main.transform.position + videoOffset;
        if (clickPos != Vector3.zero)
        {
            bool isInVideoRange = Vector3.Distance(Camera.main.transform.position, clickPos) < videoRange;
            if (isInVideoRange != withinVideoRange)
            {
                withinVideoRange = isInVideoRange;
                if (!withinVideoRange) ExitAngelVideo.Invoke();
            }
            Debug.Log("Within video range: " + withinVideoRange);
        }
    }

    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(250,180,20);
        clickPos = Camera.main.transform.position;
        AngelClick.Invoke();
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = (defaultColor * 0.8f);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
    }

    //takes content from angel's destinationManager and gives it to canvasManager
    public void Populate()
    {
        canMan.PopulateBoxes(gameObject.GetComponent<DestinationManager>());
    }

    //activates the historical map and the button to turn it off
    public void ActivateHistoryMode()
    {
        map.SetActive(true);
        exitButton.SetActive(true);
    }

    //deactivates the historical map and the button to turn it off
    public void DeactivateHistoryMode()
    {
        map.SetActive(false);
        exitButton.SetActive(false);
    }

}
