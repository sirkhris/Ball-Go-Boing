using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDynam : MonoBehaviour
{
    public float horzSpeed = 0.0f;
    public float vertSpeed = 0.0f;
    public float maxDistanceX = 0.0f;
    public float maxDistanceY = 0.0f;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement of platform if statement
        this.transform.Translate(horzSpeed * Time.fixedDeltaTime, 0, 0);

        if (this.transform.position.x <= (initialPosition.x - maxDistanceX))
        {
            InvertH();
        }
        else if (this.transform.position.x >= (initialPosition.x + maxDistanceX))
        {
            InvertH();
        }

        //vertical movement of platform if statement
        this.transform.Translate(0, vertSpeed * Time.fixedDeltaTime, 0);

        if (this.transform.position.y <= (initialPosition.y - maxDistanceY))
        {
            InvertV();
        }
        else if (this.transform.position.y >= (initialPosition.y + maxDistanceY))
        {
            InvertV();
        }
    }

    private void InvertH()
    {
        horzSpeed *= -1;
    }

    private void InvertV ()
    {
        vertSpeed *= -1;
    }
}
