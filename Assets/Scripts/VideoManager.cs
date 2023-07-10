using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


//takes in a list of videos from a destinationManager through canvasManager.
//Then controls the video plane according to the buttons on the LBox2 canvas.

public class VideoManager : MonoBehaviour
{
    [SerializeField] GameObject videoPlane;
    List<VideoClip> vidlist;

    int index = 0;

    //takes in a list of videos
    public void PopulateContent(List<VideoClip> vl, Transform t)
    {
        vidlist = vl;
        videoPlane.transform.position = t.transform.position;
        videoPlane.transform.rotation = t.transform.rotation;
        Debug.Log(videoPlane.transform.position);
        RefreshVideoDisplay();
    }

    //changes to next video
    public void AdvanceVideo()
    {
        index++;
        if (index >= vidlist.Count)
        {
            index = 0;
        }
        RefreshVideoDisplay();
    }

    //changes to previous video
    public void RegressVideo()
    {
        index--;
        if (index < 0)
        {
            index = (vidlist.Count - 1);
        }
        RefreshVideoDisplay();
    }

    //sets the video plane active
    public void ActivateVideo()
    {
        videoPlane.SetActive(true);
    }

    //sets the video plane inactive
    public void DeactivateVideo()
    {
        videoPlane.SetActive(false);
    }

    //changes the video on the video plane
    public void RefreshVideoDisplay()
    {
        videoPlane.GetComponent<VideoPlayer>().clip = vidlist[index];
    }
}
