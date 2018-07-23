using UnityEngine;

public class player_movement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 100f;
    public float rotateSpeed = 1000;
    public float upForce = 800f;
    private float jumpWaitTime = 0.5f;
    public bool canDoubleJump = false;
    public float jumpAllowedTime;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Movement
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * forwardForce);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-transform.forward * forwardForce);
        }

        // Jump
        if (IsGrounded())
        {
            jumpAllowedTime = 0;
        }
        if (Input.GetKey("space"))
        {
            if (IsGrounded())
            {
                canDoubleJump = true;
                jumpAllowedTime = Time.time + jumpWaitTime;
                rb.AddForce(transform.up * upForce);
            }
            else if (canDoubleJump && Time.time > jumpAllowedTime)
            {
                canDoubleJump = false;
                rb.AddForce(transform.up * upForce);
            }
        }

        // Rotate
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -1, 0);
        }
    }

    bool IsGrounded() {
        return (Physics.Raycast(rb.transform.position, Vector3.down, 1f)); 
    }
}
