using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{

    public float intensity = 3;
    public float minAngle = 30;
    public float maxAngle = 65;
    public float speed = 4;

    private float currentAngle = 30;
    private float angleTarget = 30;
    private float intensityTarget = 3;
    private Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    public void Minimize() {
        angleTarget = minAngle;
        intensityTarget = intensity;
    }

    public void Maximize() {
        angleTarget = maxAngle;
        intensityTarget = intensity;
    }

    public void Deactivate() {
        angleTarget = maxAngle;
        intensityTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        spotlight.spotAngle = Mathf.Lerp(spotlight.spotAngle, angleTarget, Time.deltaTime * speed);
        spotlight.intensity = Mathf.Lerp(spotlight.intensity, intensityTarget, Time.deltaTime * speed);
    }
}
