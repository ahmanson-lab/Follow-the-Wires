using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;


//takes images and videos from a CanvasManager and displays them in a carousel.
//the carousel cycles through a set of images.
//the images correspond to videos, but those are controlled separately by the videoManager script.

public class LboxTwoContentManager : MonoBehaviour
{
    
    //initialize variables in inspector
    [SerializeField] Sprite defaultImage;


    //list of sprites for small box
    List<Sprite> smallSprites;


    //identify buttons for this panel
    [SerializeField] GameObject prevButton;
    [SerializeField] GameObject nextButton;


    //create index to keep track of which image we're on in the carousel
    int smallIndex = 0;


    //take in content from a DestinationManager through CanvasManager
    public void PopulateContent(List<Sprite> ssl)
    {
        smallSprites = ssl;
    }

    //advances and loops the carousel
    public void AdvanceCarousel()
    {
        smallIndex++;
        if (smallIndex >= smallSprites.Count)
        {
            smallIndex = 0;
        }
        RefreshImageDisplay();
    }

    //regresses and loops the carousel
    public void RegressCarousel()
    {
        smallIndex--;
        if (smallIndex < 0)
        {
            smallIndex = (smallSprites.Count - 1);
        }
        RefreshImageDisplay();
    }

    //triggered on entering a destination
    public void InitializeDisplay()
    {
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        RefreshImageDisplay();
    }

    //triggered on leaving a destination
    public void ReturnToDefault()
    {
        gameObject.GetComponent<Image>().sprite = defaultImage;
        prevButton.SetActive(false);
        nextButton.SetActive(false);
    }

    //updates sprite displayed
    public void RefreshImageDisplay()
    {
        gameObject.GetComponent<Image>().sprite = smallSprites[smallIndex];
    }
}
