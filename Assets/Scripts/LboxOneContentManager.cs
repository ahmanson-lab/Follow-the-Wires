using System.Collections;
using System.Collections.Generic;
using Opertoon.Panoply;
using UnityEngine;
using UnityEngine.UI;


//takes images and videos from a CanvasManager and displays them in a carousel.
//the carousel can expand and shrink.
//the carousel in "shrunk" or small mode cycles through a set of small images.
//the expanded carousel cycles through different sets of large images, depending on which small image was being displayed when it was expanded.

public class LboxOneContentManager : MonoBehaviour
{
    //initialize variables in inspector
    [SerializeField] Sprite defaultImage;


    //list of sprites for small box
    List<Sprite> smallSprites;


    //lists of sprites for expanded box
    DestinationManager.LargeSpriteList listOfLargeSpriteLists;


    //identify buttons for this panel
    [SerializeField] GameObject prevButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject expandButton;
    [SerializeField] GameObject shrinkButton;


    //create index to keep track of which image we're on in the carousel
    int smallIndex = 0;
    int largeIndex = 0;

    
    public bool isExpanded = false;


    //take in content from a DestinationManager through CanvasManager
    public void PopulateContent(List<Sprite> ssl, DestinationManager.LargeSpriteList lsl)
    {
        smallSprites = ssl;
        listOfLargeSpriteLists = lsl;
    }

    //advances and loops the carousel, both expanded and shrunk
    public void AdvanceCarousel()
    { 
        if(isExpanded)
        {
            if(smallIndex < listOfLargeSpriteLists.list.Count)
            {
                largeIndex++;
                if (largeIndex >= listOfLargeSpriteLists.list[smallIndex].largeSpritesList.Count)
                {
                    largeIndex = 0;
                }
                RefreshImageDisplay();
            }
        }
        else
        {
            smallIndex++;
            if (smallIndex >= smallSprites.Count)
            {
                smallIndex = 0;
            }
            RefreshImageDisplay();
        }
    }

    //regresses and loops the carousel, both expanded and shrunk
    public void RegressCarousel()
    {
        if(isExpanded)
        {
            largeIndex--;
            if (largeIndex < 0)
            {
                largeIndex = (listOfLargeSpriteLists.list[smallIndex].largeSpritesList.Count-1);
            }
            RefreshImageDisplay();
        }
        else
        {
            smallIndex--;
            if (smallIndex < 0)
            {
                smallIndex = (smallSprites.Count - 1);
            }
            RefreshImageDisplay();
        }
    }

    //triggered with expand button
    public void ExpandBox()
    {
        largeIndex = 0;
        isExpanded = true;
        PanoplyCore.SetInterpolatedStep(0);
        PanoplyCore.SetTargetStep(1);
        RefreshImageDisplay();
        expandButton.SetActive(false);
        shrinkButton.SetActive(true);
    }

    //triggered with shrink button
    public void ShrinkBox()
    {
        PanoplyCore.SetInterpolatedStep(1);
        PanoplyCore.SetTargetStep(0);
        isExpanded = false;
        expandButton.SetActive(true);
        shrinkButton.SetActive(false);
        RefreshImageDisplay();
    }

    //triggered on entering a destination
    public void InitializeDisplay()
    {
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        expandButton.SetActive(true);
        RefreshImageDisplay();
    }

    //triggered on leaving a destination
    public void ReturnToDefault()
    {
        gameObject.GetComponent<Image>().sprite = defaultImage;
        prevButton.SetActive(false);
        nextButton.SetActive(false);
        expandButton.SetActive(false);
    }

    //updates sprite displayed
    public void RefreshImageDisplay()
    {
        if (isExpanded)
        {
            if(smallIndex < listOfLargeSpriteLists.list.Count)
            {
                gameObject.GetComponent<Image>().sprite = listOfLargeSpriteLists.list[smallIndex].largeSpritesList[largeIndex];
            }
            else
            {
                Debug.Log("more small sprites than large sprite lists");
            }
        }
        else if(isExpanded == false)
        {
            if(smallIndex < listOfLargeSpriteLists.list.Count)
            {
            gameObject.GetComponent<Image>().sprite = smallSprites[smallIndex];
            }
        }
    }
}