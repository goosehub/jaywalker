using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;

public class player_movement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 30f;
    public float sidewaysSpeed = 50f;
    public float mouseRotateSpeed = 5f;
    private bool loading;
    private bool victory = false;
    public Text timerText;
    public float gameTime;
    public float secondsAfterVictory = 4;

    // Use this for initialization
    void Start()
    {
        startLoading();
    }

    void startLoading()
    {
        loading = true;
        Cursor.visible = false;
        Time.timeScale = 10f;
        StartCoroutine(finishLoading());
    }

    IEnumerator finishLoading()
    {
        yield return new WaitForSeconds(20);
        Time.timeScale = 1f;
        loading = false;
    }

    void UpdateTimerText()
    {
        if (victory)
        {
            return;
        }
        gameTime += Time.deltaTime;
        timerText.text = Math.Round(gameTime, 1).ToString();
    }

    void FixedUpdate()
    {
        if (loading)
        {
            return;
        }
        KeyMovement();
        SlowPlayer();
        UpdateTimerText();
        CheckForVictory();

        QuickLookBehind();
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


        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.rotation = Quaternion.LookRotation(transform.position - rb.position);
        }
    }

    void SlowPlayer()
    {
        rb.velocity *= 9f / 10f;
    }

    private void CheckForVictory()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 5f);
        if (hit.collider.tag == "Finish")
        {
            victory = true;
            timerText.color = new Color(0.2f, 0.9f, 0.2f);
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        yield return new WaitForSeconds(secondsAfterVictory);
        string oldSceneNumber = Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value;
        int newSceneNumber = Int32.Parse(oldSceneNumber) + 1;
        SceneManager.LoadScene("scene_" + newSceneNumber);
    }

    // Not in use
    private void QuickLookBehind()
    {
        if (Input.GetKey("q"))
        {
        }
    }

    // Not in use
    bool IsGrounded() {
        return (Physics.Raycast(rb.transform.position, Vector3.down, 1f)); 
    }
}
