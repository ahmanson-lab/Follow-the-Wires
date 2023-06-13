using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//acts as a relay for content between the destinationManagers and LboxOneContentManager and LboxTwoContentManager

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject lb1;
    [SerializeField] GameObject lb2;
    [SerializeField] GameObject lb3;
    [SerializeField] GameObject videoManagerObj;


    //called by each destination in order to put their contents in the lboxes
    public void PopulateBoxes(DestinationManager dest)
    {
        lb1.GetComponent<LboxOneContentManager>().PopulateContent(dest.box1SmallSprites, dest.listOfLargeSpriteLists);
        lb2.GetComponent<LboxTwoContentManager>().PopulateContent(dest.box2SmallSprites);
        videoManagerObj.GetComponent<VideoManager>().PopulateContent(dest.videos, dest.videoPosAndRot.transform);
    }
}
