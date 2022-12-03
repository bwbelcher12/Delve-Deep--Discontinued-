using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController: MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    private GameObject target;
    private GameObject tileGenerator;
    public Colorer colorer;
    private bool targetReached;
    private bool findingTarget;
    private Vector3 targetPosition;
    private GameManager gm;


    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        tileGenerator = GameObject.Find("Tile Generator");

        targetReached = true;
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver || gm.isPaused)
        {
            return;
        }
        if (!targetReached)
        {
            MoveToTarget();
        }
        else
        {
            if (!findingTarget)
            {
                Invoke(nameof(FindTarget), 1);
                findingTarget = true;
            }

            target.GetComponent<Colorer>().isTarget = false;
            //StartCoroutine(target.GetComponent<Colorer>().BackToOldColor());
        }
    }

    void FindTarget()
    {
        GameObject[,] gameBoard = tileGenerator.GetComponent<TileSpawner>().gameBoard;

        int randomX, randomY;

        randomX = Random.Range(0, gameBoard.GetLength(0));
        randomY = Random.Range(0, gameBoard.GetLength(1));

        target = (gameBoard[randomX, randomY]);

        colorer = target.GetComponent<Colorer>();

        if (colorer.isTarget)
        {
            FindTarget();
        }
        else
        {
            //colorer.ColorTarget();

            targetReached = false;
            findingTarget = false;

            colorer.isTarget = true;
        }        
    }

    void MoveToTarget()
    {
        if(!targetReached)
        {
            float step = speed * Time.deltaTime;

            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + .35f, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if(transform.position == targetPosition)
            {
                targetReached = true;
            }
        }
    }
}
