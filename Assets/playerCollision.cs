using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour {

    public player_movement movement;
    public Rigidbody rb;
    public float bounceUpForce = 1000f;
    public float secondsAfterDeath = 5;
    public AudioSource audioData;
    public Text timerText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            rb.AddForce(transform.up * bounceUpForce);
            rb.constraints = RigidbodyConstraints.None;
            movement.enabled = false;
            timerText.color = new Color(1f, 0f, 0f);
            audioData.Play(0);
            StartCoroutine(reloadScene());
        }
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(secondsAfterDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        Reset();
    }

    private void Reset()
    {
        // Reset
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (rb.position.y < -500)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
