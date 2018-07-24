using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour {

    public player_movement movement;
    public Rigidbody rb;
    public float bounceUpForce = 1000f;
    public float secondsAfterDeath = 5;
    public AudioSource audioData;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            rb.AddForce(transform.up * bounceUpForce);
            movement.enabled = false;
            audioData.Play(0);
            StartCoroutine(reloadScene());
        }
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(secondsAfterDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
