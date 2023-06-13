using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{//https://www.youtube.com/watch?v=T1masuI3g8Q 
    private float checkTime = 0.001f;
    private Vector2 oldPos;
    public PlayerController mapIcon; // the player sprite you have the script attached on
 
    // Update is called once per frame
    void Update()
    {
        if (checkTime <= 0)
        {
            oldPos = transform.position;
            checkTime = 0.001f;
        }
        else
        {
            checkTime -= Time.captureDeltaTime;
        }

        if (Vector2.Distance(transform.position, oldPos) < 0.01f)
        {
            mapIcon.moveSpeed = 0;
        }
        else
        {
            mapIcon.moveSpeed = 10; // the player speed you set in the inspector
        }
    }
}
