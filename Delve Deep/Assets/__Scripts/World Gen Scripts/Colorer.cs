using System.Collections;
using UnityEngine;

public class Colorer : MonoBehaviour
{
    public bool isTarget;
    private float pulseSpeed = 2;
    private Color oldColor;
    private GameObject enemySpawnController;
    private GameManager gm;


    private void Awake()
    {
        enemySpawnController = GameObject.Find("Enemy Spawner");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    public IEnumerator BackToOldColor()
    {
        Color lerpedColor;
        Color currentColor = GetComponent<Renderer>().material.color;

        float x = 0;

        while (x <= 1)
        {
            lerpedColor = Color.Lerp(currentColor, oldColor, Mathf.PingPong(Time.time, 1));

            GetComponent<Renderer>().material.color = lerpedColor;

            x += .05f + Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator BackToOldColor(Color currentColor)
    {
        Color lerpedColor;

        float x = 0;

        while (x <= 1)
        {
            lerpedColor = Color.Lerp(currentColor, oldColor, Mathf.PingPong(Time.time, 1));

            GetComponent<Renderer>().material.color = lerpedColor;

            x += .05f + Time.deltaTime;

            yield return null;
        }
    }


    Color GetColor()
    {
        return GetComponent<Renderer>().material.color;
    }

    public void ColorSpawns()
    {
        StartCoroutine(Pulse(this.gameObject));
        
    }

    IEnumerator Pulse(GameObject tile)
    {
        Color startingColor = tile.GetComponent<Renderer>().material.color;
        Color targetColor = new Color(0.7924528f, 0.06354576f, 0.06354576f);
        Color lerpedColor;
        float x = 0;

        for (int i = 0; i < 2; i++)
        {
            while (x <= 1)
            {
                while(gm.isPaused)
                {
                    yield return null;
                }

                lerpedColor = Color.Lerp(startingColor, targetColor, Mathf.PingPong(x, 1));
                tile.GetComponent<Renderer>().material.color = lerpedColor;

                x += pulseSpeed * Time.deltaTime;

                yield return null;
            }
            while (x >= 0)
            {
                while (gm.isPaused)
                {
                    yield return null;
                }

                lerpedColor = Color.Lerp(startingColor, targetColor, Mathf.PingPong(x, 1));
                tile.GetComponent<Renderer>().material.color = lerpedColor;

                x -= pulseSpeed * Time.deltaTime;

                yield return null;
            }
        }
        while (x <= 1)
        {
            while (gm.isPaused)
            {
                yield return null;
            }

            lerpedColor = Color.Lerp(startingColor, targetColor, Mathf.PingPong(x, 1));
            tile.GetComponent<Renderer>().material.color = lerpedColor;

            x += pulseSpeed * Time.deltaTime;

            yield return null;
        }

        enemySpawnController.GetComponent<EnemySpawnController>().spawnEnemies(this.gameObject);

        StartCoroutine(BackToOldColor(startingColor));

        yield return null;
    }
}