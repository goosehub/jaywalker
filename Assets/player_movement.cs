using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 30f;
    public float sidewaysSpeed = 50f;
    public float rotateSpeed = 1000;
    public float upForce = 500f;
    public float mouseRotateSpeed = 5f;
    private float jumpWaitTime = 0.5f;
    public bool canDoubleJump = false;
    public float jumpAllowedTime;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Reset
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Movement
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * forwardForce);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-transform.forward * forwardForce);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * forwardForce);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-transform.right * forwardForce);
        }

        // Rotate
        if (Input.GetKey("e"))
        {
            transform.Rotate(0, 1 * rotateSpeed, 0);
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(0, -1 * rotateSpeed, 0);
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, 1 * mouseRotateSpeed, 0);
        }
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, -1 * mouseRotateSpeed, 0);
        }
        // transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        // rb.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * mouseRotateSpeed);

        return;

        return;

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
    }

    bool IsGrounded() {
        return (Physics.Raycast(rb.transform.position, Vector3.down, 1f)); 
    }
}
