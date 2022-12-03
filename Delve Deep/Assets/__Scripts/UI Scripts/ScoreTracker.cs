using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    TMPro.TMP_Text scoreTracker;
    float score;


    // Start is called before the first frame update
    void Awake()
    {
        scoreTracker = GetComponent<TMPro.TMP_Text>();
        scoreTracker.text = "Gems Collected: ";
        score = 0f;
        UpdateScore(0);
    }

    public float GetScore()
    {
        return score;
    }

    public void UpdateScore(float addedScore)
    {
        score += addedScore;

        scoreTracker.text = "Gems Collected: " + score;
    }

    
}
