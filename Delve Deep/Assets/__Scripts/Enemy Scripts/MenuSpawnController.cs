using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject tileGenerator;

    public List<GameObject> spawnerTiles;

    public int wave;

    private void Start()
    {
        NewWave();
    }

    public void NewWave()
    {
        PickSpawns(wave);

        foreach (GameObject tile in spawnerTiles)
        {
            tile.GetComponent<Colorer>().ColorSpawns();
        }
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

            spawnEnemies(gameBoard[randomX, randomY]);
        }
    }

    public void spawnEnemies(GameObject tile)
    {
        Instantiate(enemyPrefab, new Vector3(tile.transform.position.x, tile.transform.position.y + .35f, tile.transform.position.z), Quaternion.identity);
    }
}
