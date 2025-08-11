using UnityEngine;


public class EnemyAi : MonoBehaviour ,IAI
{
    [SerializeField] ObstacleGridData obstacleGridData;
    private Vector2Int position;
    private Vector2Int playerPosition;
    private Vector2Int closestPos;

    //Enemy only move the adjacent so posible direction
    Vector2Int[] directions = new Vector2Int[]
    {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
    };
    public void Onmove(Vector2Int currentPosition)
    {
        playerPosition = currentPosition;
        ClosestDistance();
        transform.position = new Vector3(closestPos.x, 1f, closestPos.y);
        
    }

    void ClosestDistance()
    {
        //Storing the current postion 
        position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
         closestPos = position;
        float closestDist = float.MaxValue;
        //Loop throught the all direction and check the closetdistance between the enmey and the player nearest one step tile index
        foreach (var dir in directions)
        {
            Vector2Int newPos = position + dir;
            if(!obstacleGridData.obstacleTiles.Contains(newPos))
            {
                float dist = Vector2Int.Distance(newPos, playerPosition);

                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestPos = newPos;
                }
            }

        }

       
    }
}
