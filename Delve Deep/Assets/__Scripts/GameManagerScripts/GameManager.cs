using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool isPaused;
    public bool hasRoundStarted;
    public float levelTime;
    public float waveDelay;

    [SerializeField] TMPro.TMP_Text gameOverText;
    [SerializeField] TMPro.TMP_Text highScoreText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] GameObject audioManager;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TMPro.TMP_Text score;

    private AudioSource am;

    private void Start()
    {
        am = audioManager.GetComponent<AudioSource>();
        am.PlayOneShot(gameMusic);
    }

    void Awake()
    {
        gameOver = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused == false)
            {
                isPaused = true;
                pauseMenu.gameObject.SetActive(true);
            }
            else
            {
                isPaused = false;
                pauseMenu.gameObject.SetActive(false);
            }


        }
    }

    public void GameOver()
    {
        gameOver = true;

        gameOverMenu.SetActive(true);

        UpdateHighScore();
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("Highscore");

        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateHighScore()
    {

        if (PlayerPrefs.GetFloat("Highscore") < score.GetComponent<ScoreTracker>().GetScore())
        {
            PlayerPrefs.SetFloat("Highscore", score.GetComponent<ScoreTracker>().GetScore());
        }

    }
}
