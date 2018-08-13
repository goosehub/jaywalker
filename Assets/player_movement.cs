using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

public class player_movement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 30f;
    public float sidewaysSpeed = 50f;
    public float mouseRotateSpeed = 5f;
    private bool loading;
    private bool victory = false;
    public float gameTime;
    public float secondsAfterVictory = 4;
    public float loadTime = 12;
    public Text timerText;
    public Text highScoreText;
    public Text ErrorText;
    public Text LevelControlText;
    public AudioSource victorySound;

    void Start()
    {
        startLoading();
    }

    void startLoading()
    {
        loading = true;
        Cursor.visible = false;
        Time.timeScale = 10f;
        loadHighScore();
        if (LevelControlText && loadHighScore() != 0)
        {
            LevelControlText.text = "N key for next level, P key for previous level";
        }
        StartCoroutine(finishLoading());
    }

    IEnumerator finishLoading()
    {
        yield return new WaitForSeconds(loadTime);
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
        timerText.text = Math.Round(gameTime, 2).ToString("0.00");
    }

    void FixedUpdate()
    {
        OtherControls();
        if (loading)
        {
            return;
        }
        KeyMovement();
        SlowPlayer();
        UpdateTimerText();
        CheckForVictory();
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

    public void OtherControls()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.rotation = Quaternion.LookRotation(transform.position - rb.position);
        }
        if (Input.GetKey("n"))
        {
            if (loadHighScore() == 0)
            {
                ErrorText.text = "Level Not Unlocked";
            }
            else
            {
                loadNextScene();
            }
        }
        if (Input.GetKey("p"))
        {
            loadPreviousScene();
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
        if (!victory && hit.collider.tag == "Finish")
        {
            victoryActions();
        }
    }

    public void victoryActions()
    {
        victory = true;
        recordNewHighScore();
        timerText.color = new Color(0.2f, 0.9f, 0.2f);
        // If this is last level, play victory sound
        if (victorySound)
        {
            victorySound.Play(0);
        }
        StartCoroutine(loadNextSceneAfterWait());
    }

    IEnumerator loadNextSceneAfterWait()
    {
        yield return new WaitForSeconds(secondsAfterVictory);
        loadNextScene();
    }

    void loadNextScene()
    {
        int newSceneNumber = Int32.Parse(getCurrentSceneNumber()) + 1;
        SceneManager.LoadScene("scene_" + newSceneNumber);
    }

    void loadPreviousScene()
    {
        int newSceneNumber = Int32.Parse(getCurrentSceneNumber()) - 1;
        SceneManager.LoadScene("scene_" + newSceneNumber);
    }

    public string getCurrentSceneNumber()
    {
        return Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value;
    }

    // Not in use
    bool IsGrounded() {
        return (Physics.Raycast(rb.transform.position, Vector3.down, 1f)); 
    }

    public void recordNewHighScore()
    {
        float currentHighScore = loadHighScore();
        float newScore = gameTime;
        if (currentHighScore != 0 && newScore >= currentHighScore)
        {
            return;
        }
        string newHighScoreString = Math.Round((float) newScore, 2).ToString("0.00");
        File.WriteAllText(highScoreFilePath(), newHighScoreString);
    }

    private float loadHighScore()
    {
        if (File.Exists(highScoreFilePath()))
        {
            string highScore = File.ReadAllText(highScoreFilePath());
            highScoreText.text = "Best Time: " + highScore;
            float parsedHighScore;
            if (float.TryParse(highScore, out parsedHighScore))
            {
                return parsedHighScore;
            }
        }
        return 0;
    }

    public string highScoreFilePath()
    {
        return "Assets/levelHighScores/highscore-level-" + getCurrentSceneNumber() + ".txt";
    }
}
