using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MenuHighScore : MonoBehaviour
{
    string path = Application.streamingAssetsPath + "/Highscore.txt";


    // Start is called before the first frame update
    void Awake()
    {
        UpdateHS();   
    }

    public void UpdateHS()
    {
        {
            if (PlayerPrefs.HasKey("Highscore").Equals(false))
            {
                PlayerPrefs.SetFloat("Highscore", 0);
            }

            GetComponent<TMPro.TMP_Text>().text = "High Score: " + PlayerPrefs.GetFloat("Highscore");
        }
    }
}
