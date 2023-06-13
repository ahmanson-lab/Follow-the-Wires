using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 currentEulerAngles;
    float x;
    float y;
    float z;
    
    float horizontalInput;
    float verticalInput;
    float wheelInput;
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;

    public static GameObject ctile;
    public static int playerlimitx = 200;
    public static int playerlimitz = 400;
    public static int tilex = 0;
    public static int tiley = 0;
    public static int tilez = 0;
    public float speed = 10;
   
    private bool coroutineon = false;
    private float delaytime = 0.01f;


    private void Start()
    {
        ctile = GameObject.Find("Floor");
    }


    private void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.B))
        {
            Quaternion target = Quaternion.Euler(180, 180, 180);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 5.0f);
        }
        else
        {
            Quaternion target = Quaternion.Euler(135, 180, 180);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 5.0f);
        }
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            // StartCoroutine(MoveUp(speed));
            if(transform.position.z < ((ctile.transform.position.z + 5 * ctile.transform.localScale.z) - playerlimitz)){
                Vector3 newPosition = transform.position;
                newPosition.z = newPosition.z + 100;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
            }
        }


        if (Input.GetKey(KeyCode.A) && coroutineon == false)
        {
            // StartCoroutine(MoveLeft(speed));
            if(transform.position.x > ((0 - ctile.transform.position.x - 5 * ctile.transform.localScale.x) + playerlimitx)){
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x - 100;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
            }
        }


        if (Input.GetKey(KeyCode.D) && coroutineon == false)
        {
            // StartCoroutine(MoveRight(speed));
            if(transform.position.x < ((ctile.transform.position.x + 5 * ctile.transform.localScale.x) - playerlimitx)){
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x + 100;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
            }
        }


        if (Input.GetKey(KeyCode.S))
        {
            // StartCoroutine(MoveDown(speed));
            if(transform.position.z > ((0 - ctile.transform.position.z - 5 * ctile.transform.localScale.z) + playerlimitz)){
                Vector3 newPosition = transform.position;
                newPosition.z = newPosition.z - 100;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
            }
        }
    }

    /*
    IEnumerator MoveUp(float speed)
    {
        coroutineon = true;
        // transform.rotation = Quaternion.Euler(0, 0, 0);
        if (transform.position.z < (playerlimitz + ctile.transform.position.z))
        {
            Vector3 newPosition = transform.position;
            newPosition.z = newPosition.z + 1;
            while (transform.position != newPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
        yield return new WaitForSeconds(delaytime);
        coroutineon = false;
    }


    IEnumerator MoveLeft(float speed)
    {
        coroutineon = true;
        // transform.rotation = Quaternion.Euler(0, -90, 0);
        if (transform.position.x > (-playerlimitx + ctile.transform.position.x))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - 1;
            while (transform.position != newPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
        yield return new WaitForSeconds(delaytime);
        coroutineon = false;
    }


    IEnumerator MoveRight(float speed)
    {
        coroutineon = true;
        // transform.rotation = Quaternion.Euler(0, 90, 0);
        if (transform.position.x < (playerlimitx + ctile.transform.position.x))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + 1;
            while (transform.position != newPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
        yield return new WaitForSeconds(delaytime);
        coroutineon = false;
    }


    IEnumerator MoveDown(float speed)
    {
        coroutineon = true;
        // transform.rotation = Quaternion.Euler(0, 180, 0);
        if (transform.position.z > (-playerlimitz + ctile.transform.position.z))
        {
            Vector3 newPosition = transform.position;
            newPosition.z = newPosition.z - 1;
            while (transform.position != newPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
        yield return new WaitForSeconds(delaytime);
        coroutineon = false;
    }
    */

}
