using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    public void ClearHS()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
