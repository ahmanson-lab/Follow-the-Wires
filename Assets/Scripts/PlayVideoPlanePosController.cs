using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoPlanePosController : MonoBehaviour
{
    public GameObject currCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log("current cam position is" + currCam.transform.position);

        if(currCam.transform.position.x > 140f){ 
            
            //Debug.Log("now at destination 2, congrats!");
            transform.position = new Vector3(160.80f, 1607.60f, -290.45f)+ new Vector3(0f,-5f ,23.5000114f);
        }
        if(currCam.transform.position.x <140f){
            //Debug.Log("now at destination 1, congrats!");   
            transform.position  = new Vector3(124.74f, 1607.60f, -290.45f) + new Vector3(0f,-5f ,23.5000114f);
        }

    }

}
