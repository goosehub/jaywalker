using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDrive : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 80f;
	
	void FixedUpdate ()
    {
        rb.velocity = transform.forward * (forwardForce);
    }
}
