using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeRemaining;

    private TMPro.TMP_Text timer;

    private GameManager gm;

    // Start is called before the first frame update
    void Awake()
    {
        timer = GetComponent<TMPro.TMP_Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        timeRemaining = gm.levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.isPaused || gm.gameOver)
        {
            return;
        }

        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;



            if (timeRemaining < 10)
            {
                timer.text = "<color=red>Time Remaining: " + timeRemaining.ToString("0.0") + "</color>";
            }
            else
            {
                timer.text = "Time Remaining: " + timeRemaining.ToString("0.0");
            }

            return;
        }

        if (timeRemaining < 0)
        {
            gm.GameOver();
        }
    }
}
