using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoIcon : MonoBehaviour
{
    [SerializeField] GameObject TutorialPanel;
    private bool hasClicked;
    void Start()
    {
        TutorialPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableTutorial()
    {
        if (!hasClicked)
        {
            TutorialPanel.SetActive(true);
            hasClicked = true;
        }
        else
        {
            TutorialPanel.SetActive(false);
            hasClicked = false;
        }
         
    }
}
