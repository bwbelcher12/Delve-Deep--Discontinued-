using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDelay : MonoBehaviour
{

    private float timeRemaining;
    private GameManager gm;

    private TMPro.TMP_Text text;
    [SerializeField] GameObject enemySpawner;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        timeRemaining = gm.waveDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.isPaused)
        {
            return;
        }

        if(gameObject.activeSelf.Equals(true))
        {
            timeRemaining -= Time.deltaTime;

            text.text = "New wave begins in: " + timeRemaining.ToString("0.0");

            if (timeRemaining < 0)
            {
                gameObject.SetActive(false);

                enemySpawner.GetComponent<EnemySpawnController>().NewWave();

                timeRemaining = gm.waveDelay;
            }
        }
    }
}
