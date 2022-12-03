using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Resume()
    {
        gm.isPaused = false;

        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
