using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

//creates drag and drop lists for each destination's content to go in.
//these are accessed by the canvasManager.

public class DestinationManager : MonoBehaviour
{

    //create expandable dropdown lists of sprites in the inspector
    public List<Sprite> box1SmallSprites;
    public List<Sprite> box2SmallSprites;


    //create an expandable list of expandable lists of sprites in the inspector
    [System.Serializable]
    public class Meow
    {
        public List<Sprite> largeSpritesList;
    }
    [System.Serializable]
    public class LargeSpriteList
    {
        public List<Meow> list;
    }
    public LargeSpriteList listOfLargeSpriteLists = new LargeSpriteList();

    //create expandable dropdown list of videos in the inspector
    public List<VideoClip> videos;
    public GameObject videoPosAndRot;

}
