using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{

    public float minAngle = 30;
    public float maxAngle = 65;
    public float speed = 4;

    private float currentAngle = 30;
    private float angleTarget = 30;
    private Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    public void Minimize() {
        angleTarget = minAngle;
    }

    public void Maximize() {
        angleTarget = maxAngle;
    }

    // Update is called once per frame
    void Update()
    {
        spotlight.spotAngle = Mathf.Lerp(spotlight.spotAngle, angleTarget, Time.deltaTime * speed);
    }
}
