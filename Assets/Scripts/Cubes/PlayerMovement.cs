using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //References
    [SerializeField] EnemyAi enemy;
    [SerializeField] ObstacleGridData obstacleGridData;
   

    public Vector2Int clickPosition;
    //Check the player is moving or not 
    public bool isMoving { get; private set; }
    //Store player postion onlu x and z y remains same 1
    public Vector2Int playerPosition {  get; private set; }
    //Check whether player is left clicked on mouse
    public bool isMouseClicked = false;

    private Vector2Int position;
    private Vector2Int currentPosition;
    private Vector2Int closestPos;
    private const float waitTime = 1f;

    // All 8 directions: 4 cardinals + 4 diagonals
    Vector2Int[] directions = new Vector2Int[]
    {
        Vector2Int.up,             // (0, 1)
        Vector2Int.down,           // (0, -1)
        Vector2Int.left,           // (-1, 0)
        Vector2Int.right,          // (1, 0)
        new Vector2Int(-1, 1),     // up-left
        new Vector2Int(1, 1),      // up-right
        new Vector2Int(-1, -1),    // down-left
        new Vector2Int(1, -1)      // down-right
    };
   
    void Start()
    {
        playerPosition = currentPosition;
    }

    void Update()
    {
        //check the click tile does not conatin a obstacle to reduce update run every frame
        if(!obstacleGridData.obstacleTiles.Contains(clickPosition))
        {
            //Checking the condition before the player start move
            if (isMouseClicked && !isMoving && currentPosition != clickPosition)
            {
                StartCoroutine(PathFinderCouroutine());
            }
            else if (currentPosition == clickPosition)
            {
                //Reset the mouseclicked to false after the player reach the destination
                isMouseClicked = false;
               
            }
        }
        else
        {
            Debug.LogWarning("Unable to Move due to abstacle ");
        }

    }


    void PlayerClosestDistance()
    {
        position = playerPosition;
        closestPos = position;
        float closestDist = float.MaxValue;


        foreach (var dir in directions)
        {
            //Adding the position and direction of the movements to move
            Vector2Int newPos = position + dir;
            if (!obstacleGridData.obstacleTiles.Contains(newPos))
            {
                //Checking the distance between two vectors return in float
                float dist = Vector2Int.Distance(newPos, clickPosition);
                //Check  the closest distance
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestPos = newPos;
                }
            }

        }
        currentPosition = closestPos;
        //Debug.Log("Player should move to: " + closestPos);

    }
    // Coroutine for the step by step moving to look like moving
    IEnumerator PathFinderCouroutine()
    {
           isMoving = true;
        
            if (currentPosition != Vector2Int.zero)
            {
                playerPosition = currentPosition;
            }

            PlayerClosestDistance();
            yield return new WaitForSeconds(waitTime);
            transform.position = new Vector3(closestPos.x, 1f, closestPos.y);
            isMoving = false ;
            if(currentPosition == clickPosition)
            {
                //if the player reach the destination then after the 1 s the enemy ai start moveing
                yield return new WaitForSeconds(waitTime);
                enemy.Onmove(currentPosition);
            }
 
    }

}
