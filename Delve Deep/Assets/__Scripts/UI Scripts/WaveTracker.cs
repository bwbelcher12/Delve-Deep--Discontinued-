using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTracker : MonoBehaviour
{
    TMPro.TMP_Text waveTracker;

    // Start is called before the first frame update
    void Awake()
    {
        waveTracker = GetComponent<TMPro.TMP_Text>();
        waveTracker.text = "       Current Wave:\n EnemiesRemaining:";
    }


    public void UpdateCount(int remainingEnemies, int wave)
    {
        waveTracker.text = "       Current Wave: " + wave + "\n Enemies Remaining: " + remainingEnemies;
    }
}
