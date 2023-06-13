using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//changes color of angel sprite in accordance with user mouse interaction
//moves the angel from left to right, and resets position based on the x value of the start and end pos objects
//triggers map and Lbox content population
//on click, triggers unity events listed in the inspector

public class AngelController : MonoBehaviour
{
    [SerializeField] CanvasManager canMan;
    [SerializeField] Transform startPos, endPos;
    [SerializeField] GameObject map;
    [SerializeField] GameObject exitButton;

    [SerializeField] float movementSpeed;
    // Update is called once per frame

    [SerializeField] UnityEvent AngelClick;
    Color defaultColor;

    private void Start()
    {
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    //moves angel and resets position
    void Update()
    {
        
        if(transform.position.x <= endPos.transform.position.x){
            transform.position = startPos.transform.position;
        }
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(250,180,20);
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
