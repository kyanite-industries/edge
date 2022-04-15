using UnityEngine;
using System;

public class rbplayermovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, -500 * Time.deltaTime, 0);
        }
    }
    
}