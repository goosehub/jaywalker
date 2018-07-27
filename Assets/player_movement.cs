using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading;

public class player_movement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 30f;
    public float sidewaysSpeed = 50f;
    public float mouseRotateSpeed = 5f;
    private bool loading;
    
    // Use this for initialization
    void Start()
    {
        startLoading();
    }

    void FixedUpdate ()
    {
        if (loading)
        {
            return;
        }
        KeyMovement();
        SlowPlayer();
    }

    void startLoading()
    {
        loading = true;
        Cursor.visible = false;
        Time.timeScale = 100f;
        StartCoroutine(finishLoading());
    }

    IEnumerator finishLoading()
    {
        yield return new WaitForSeconds(10);
        Time.timeScale = 1f;
        loading = false;
    }

    void SlowPlayer()
    {
        rb.velocity *= 9f/10f;
    }

    private void KeyMovement()
    {
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
    }

    bool IsGrounded() {
        return (Physics.Raycast(rb.transform.position, Vector3.down, 1f)); 
    }
}
