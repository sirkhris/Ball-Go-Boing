using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRotation : MonoBehaviour
{
    public float spinSpeed = 0.0f;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotation of platform
        this.transform.Rotate(0, 0, spinSpeed * Time.fixedDeltaTime);
    }
    private void InvertR()
    {
        spinSpeed *= -1;
    }
}

