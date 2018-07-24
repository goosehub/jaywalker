using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDrive : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 80f;
    public AudioSource audioData;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.velocity = transform.forward * (forwardForce);
        // rb.velocity = new Vector3(0, 0, forwardForce);
    }
}
