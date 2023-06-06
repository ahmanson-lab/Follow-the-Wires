using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonClickTest : MonoBehaviour
{
    UnityEvent m_MyEvent;
    public List<Sprite> backgroundImageList = new List<Sprite>(); // List of images
    // Start is called before the first frame update
    public Canvas targetCanvas; // The canvas to change the background image

    private int currentIndex = 0; // Index of the current image in the list
    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();
        // Set the initial background image to the first one in the list
        SetBackgroundImage(backgroundImageList[currentIndex]);
    }
    
    void SetBackgroundImage(Sprite backgroundImage)
    {
        // Get the canvas' RawImage component
        RawImage rawImage = targetCanvas.GetComponent<RawImage>();

        // If the canvas doesn't have a RawImage component, add one
        if (rawImage == null)
        {
            rawImage = targetCanvas.gameObject.AddComponent<RawImage>();
        }

        // Set the RawImage's texture to the background image
        rawImage.texture = backgroundImage.texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ClickTest()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    public void PreviousImg()
    {
        Debug.Log("get prev image");
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = backgroundImageList.Count - 1;
        }

        // Set the new background image
        SetBackgroundImage(backgroundImageList[currentIndex]);
        
    }

    public void NextImg()
    {
        Debug.Log("get next image");
        currentIndex++;
        if (currentIndex >= backgroundImageList.Count)
        {
            currentIndex = 0;
        }

        // Set the new background image
        SetBackgroundImage(backgroundImageList[currentIndex]);
        
    }
}
