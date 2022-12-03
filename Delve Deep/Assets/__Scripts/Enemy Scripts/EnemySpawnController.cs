using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject tileGenerator;
    [SerializeField] private TMPro.TMP_Text waveCounter;

    public List<GameObject> spawnerTiles;

    public int wave;
    public bool waveActive;
    public int enemyCount;
    public int waveCount;

    [SerializeField] private int pulseSpeed;
    [SerializeField] TMPro.TMP_Text waveClearText;
    [SerializeField] TMPro.TMP_Text waveDelay;



    private void Start()
    { 
        waveActive = false;
        enemyCount = 0;
        waveCount = 0;

        NewWave();
    }

    private void Update()
    {
        if (enemyCount <= 0)
        {
            waveActive = false;
            
            //Call WaveClear once
            if (waveClearText.isActiveAndEnabled.Equals(false) && waveActive.Equals(false))
            {
                WaveClear();
            }
        }
    }

    public void NewWave()
    {
        waveCount++;
        enemyCount = wave;
        UpdateWaveCounter();

        PickSpawns(wave);

        foreach (GameObject tile in spawnerTiles)
        {
            tile.GetComponent<Colorer>().ColorSpawns();
        }

        waveActive = true;
    }

    public void UpdateWaveCounter()
    {
        waveCounter.GetComponent<WaveTracker>().UpdateCount(enemyCount, waveCount);
    }

    void PickSpawns(int wave)
    {
        GameObject[,] gameBoard = tileGenerator.GetComponent<TileSpawner>().gameBoard;
        spawnerTiles.Clear();

        for (int i = 0; i < wave; i++)
        {
            int randomX, randomY;

            randomX = Random.Range(0, gameBoard.GetLength(0));
            randomY = Random.Range(0, gameBoard.GetLength(1));

            spawnerTiles.Add(gameBoard[randomX, randomY]);
        }
    }

    private void WaveClear()
    {
        waveClearText.gameObject.SetActive(true);
        waveClearText.text = "Wave " + waveCount + " clear";
        StartCoroutine(waveClearText.GetComponent<UIFade>().Fade(1, 1, 10));

        waveDelay.gameObject.SetActive(true);
    }

    public void spawnEnemies(GameObject tile)
    {
        Instantiate(enemyPrefab, new Vector3(tile.transform.position.x, tile.transform.position.y + .35f, tile.transform.position.z), Quaternion.identity);
    }
}
