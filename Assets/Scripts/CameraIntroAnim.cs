using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntroAnim : MonoBehaviour
{
    // Start is called before the first frame update
    /*  public GameObject Camera;
      public Vector3 EndCameraPos;
      public float movementSpeed;*/

    public Animator CameraAnimator;
    void Start()
    {
        //Debug.Log(Camera.transform.position  + "beginning");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMovement()
    {
        Debug.Log("start camera aniamtion");
        //MovingTo(EndCameraPos, movementSpeed);
        CameraAnimator.SetTrigger("Start");
    }

    public void StartTutorial()
    {
        Debug.Log("start tutorial aniamtion");
        //MovingTo(EndCameraPos, movementSpeed);
        CameraAnimator.SetTrigger("Start");
    }

    /* IEnumerator MovingTo(Vector3 pos, float speed)
     {

         yield return new WaitForSeconds(1.0f);



         while (Camera.transform.position != pos)
         {

             Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, pos, speed * Time.deltaTime * 60);
             Debug.Log(Camera.transform.position + "in between");

             if (Vector3.Distance(transform.position, pos) <= 0.01f)
             {
                 Camera.transform.position = pos;
                 break;
             }
             yield return null;

         }

     }*/
}
