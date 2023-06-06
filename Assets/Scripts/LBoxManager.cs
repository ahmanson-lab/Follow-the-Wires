using System.Collections;
using System.Collections.Generic;
using Opertoon.Panoply;
using UnityEngine;
using UnityEngine.UI;

public class LBoxManager : MonoBehaviour
{
    [SerializeField] Sprite defaultImage;
    //identify buttons for this panel
    [SerializeField] GameObject prevButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject expandButton;
    [SerializeField] GameObject shrinkButton;
    [SerializeField] bool canExpand;

    bool isExpanded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //triggered with expand button
    public void ExpandBox()
    {
        if(canExpand)
        {
            //largeIndex = 0;
            isExpanded = true;
            PanoplyCore.SetInterpolatedStep(4);
            PanoplyCore.SetTargetStep(4);
            DisplayImage(defaultImage);
            expandButton.SetActive(false);
            shrinkButton.SetActive(true);
        }
    }

    //triggered with shrink button
    public void ShrinkBox()
    {
        if (canExpand)
        {
            PanoplyCore.SetInterpolatedStep(0);
            PanoplyCore.SetTargetStep(0);
            isExpanded = false;
            expandButton.SetActive(true);
            shrinkButton.SetActive(false);
            //DisplayImage();
        }
    }

    //triggered on entering a destination
    public void InitializeDisplay()
    {
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        if (canExpand)
        {
            expandButton.SetActive(true);
        }
    }

    //triggered on leaving a destination
    public void ReturnToDefault()
    {
        GetComponent<Image>().sprite = defaultImage;
        prevButton.SetActive(false);
        nextButton.SetActive(false);
        if (canExpand)
        {
            expandButton.SetActive(false);
        }
    }

    //updates sprite displayed
    public void DisplayImage(Sprite img)
    {
        GetComponent<Image>().sprite = img;
    }
}
