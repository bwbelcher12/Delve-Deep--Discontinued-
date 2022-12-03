using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnemyMovementController: MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    private GameObject target;
    private GameObject tileGenerator;
    private bool targetReached;
    private bool findingTarget;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Awake()
    {
        tileGenerator = GameObject.Find("Tile Generator");

        targetReached = true;
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    void FindTarget()
    {
        GameObject[,] gameBoard = tileGenerator.GetComponent<TileSpawner>().gameBoard;

        int randomX, randomY;

        randomX = Random.Range(0, gameBoard.GetLength(0));
        randomY = Random.Range(0, gameBoard.GetLength(1));

        target = (gameBoard[randomX, randomY]);

        targetReached = false;
        findingTarget = false;
             
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
