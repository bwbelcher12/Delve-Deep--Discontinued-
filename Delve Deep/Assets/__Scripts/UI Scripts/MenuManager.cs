using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject audioManager;
    [SerializeField] AudioClip menuMusic;

    private AudioSource am;

    public void Awake()
    {
        am = audioManager.GetComponent<AudioSource>();

        am.PlayOneShot(menuMusic);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Cave");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

