using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private Material wallMat;
    private GameObject currentTile;

    [SerializeField] private float width;
    [SerializeField] private float height;

    private Vector3 tilePos;
    private Vector3 startPos;
    [SerializeField] public GameObject[,] gameBoard;

    void Awake()
    {
        SpawnTiles();
        CreateEnvironment();
    }

    // This script will simply instantiate the Prefab when the game starts.
    void SpawnTiles()
    {
        gameBoard = new GameObject[Mathf.Abs((int)height), Mathf.Abs((int)width)];
        startPos = new Vector3((-(width / 2)) + .5f, 0, ((height / 2)- .5f)); //Set postion of first tile so that board is centered in screen.
        spawner.transform.position = startPos;

        tilePos = startPos;

        int tileNum = 0;
        float randomColor;
        Color customColor;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                currentTile = Instantiate(tile, new Vector3(tilePos.x, 0, tilePos.z), Quaternion.identity) as GameObject;
                currentTile.name = "Tile " + tileNum;

                tilePos = new Vector3 (currentTile.transform.position.x + 1, 0, currentTile.transform.position.z); //Step through each row

                randomColor = Random.Range(.2f, .6f);

                customColor = new Color(randomColor, randomColor, randomColor, 1.0f);
                var cubeRenderer = currentTile.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", customColor);

                gameBoard[i, j] = currentTile;

                tileNum++;
            }
            tilePos = new Vector3(startPos.x, 0, currentTile.transform.position.z - 1); //Step through each column
        }
    }

    void CreateEnvironment()
    {

        GameObject wall;
        //create left wall
        wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = new Vector3(startPos.x - 1.05f, startPos.y, startPos.z - (height/2) + .5f);
        wall.transform.localScale = new Vector3(1, 5, height + .1f);

        
        var cubeRenderer = wall.GetComponent<Renderer>();
        cubeRenderer.material = wallMat;

        Rigidbody wallRb = wall.AddComponent<Rigidbody>();
        wallRb.isKinematic = true;

        //create back wall
        wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = new Vector3(startPos.x + (width/2) - .5f, startPos.y, startPos.z + 1.05f);
        wall.transform.localScale = new Vector3(width + .1f, 5, 1);

        cubeRenderer = wall.GetComponent<Renderer>();
        cubeRenderer.material = wallMat;

        wallRb = wall.AddComponent<Rigidbody>();
        wallRb.isKinematic = true;

        //create right wall
        wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = new Vector3(startPos.x + width + .05f, startPos.y, startPos.z - (height / 2) + .5f);
        wall.transform.localScale = new Vector3(1, 5, height + .1f);

        cubeRenderer = wall.GetComponent<Renderer>();
        cubeRenderer.material = wallMat;

        wallRb = wall.AddComponent<Rigidbody>();
        wallRb.isKinematic = true;

        //create front wall
        wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = new Vector3(startPos.x + (width / 2) - .5f, startPos.y, startPos.z - height - .05f);
        wall.transform.localScale = new Vector3(width + .1f, 5, 1);

        cubeRenderer = wall.GetComponent<Renderer>();
        cubeRenderer.material = wallMat;
        Color matColor = wallMat.color;
        matColor.a = 0f;
        wallMat.color = matColor;
        cubeRenderer.enabled = false;

        wallRb = wall.AddComponent<Rigidbody>();
        wallRb.isKinematic = true;
    }
}
