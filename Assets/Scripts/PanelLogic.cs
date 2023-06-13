using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;
using Opertoon.Panoply;

public class PanelLogic : MonoBehaviour
{
    public GameObject stateGraph;
    public Panel mainPanel;
    public Panel mapPanel;
    public Panel informationPanel;
    public Panel imageryPanel;
    private LboxOneContentManager lb1;

    // Start is called before the first frame update
    void Start()
    {
        PanoplyEventManager.OnTargetStepChanged += HandleTargetStepChanged;
        lb1 = FindAnyObjectByType<LboxOneContentManager>();
    }

    public void HandleTargetStepChanged(int oldStep, int newStep)
    {
        CustomEvent.Trigger(stateGraph, "TargetStepChanged", oldStep, newStep);
    }

    private void MainPanelClicked()
    {
        CustomEvent.Trigger(stateGraph, "MainPanelClicked");
    }

    private void MapPanelClicked()
    {
        CustomEvent.Trigger(stateGraph, "MapPanelClicked");
    }

    private void InformationPanelClicked()
    {
        CustomEvent.Trigger(stateGraph, "InformationPanelClicked");
    }

    private void ImageryPanelClicked()
    {
        CustomEvent.Trigger(stateGraph, "ImageryPanelClicked");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (informationPanel.camera.pixelRect.Contains(Input.mousePosition))
            {
                InformationPanelClicked();
            }
            else if (imageryPanel.camera.pixelRect.Contains(Input.mousePosition))
            {
                ImageryPanelClicked();
            }
            else if (mainPanel.camera.pixelRect.Contains(Input.mousePosition))
            {
                MainPanelClicked();
                
                //yuwei: I couldn't figure out how to add in the state machine
                //to solve the bug about shrinking, the idea is to force call the shrink box funtino when we click on the main panel;
                if (lb1.isExpanded)
                    lb1.ShrinkBox();
            }
        }
    }
}

