using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfomGenerator : MonoBehaviour
{

    [SerializeField] GameObject platform;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] ObstacleGridData obstacleGridData;
    [SerializeField] Transform platformParent;
    [SerializeField] Transform obstacleparent;
    [SerializeField] int rows;
    [SerializeField] int columns;

    private void Start()
    {
        //Call at the start of the script
        Generateplatform();
    }

    void Generateplatform()
    {
        // Generate a tile up do respective rows and colums
        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                //Store the location of the sapwn tilw eg: first tile spawn in x=0,z=0, next x=0 ,z=1 etc
                Vector3 location = new Vector3(i , 0 , j );
                //Spawm the Tile cube
               GameObject cube = Instantiate(platform,location , Quaternion.identity , platformParent);
                //Set the tile detail in respective spawned new tile
                SetPlatformPosition(cube,i,j);
                Vector2Int vector2 = new Vector2Int(i, j);
                //Spawn the obstacle in the certain tile
                if(obstacleGridData.obstacleTiles.Contains(vector2))
                {
        
                    Instantiate(obstaclePrefab, new Vector3(vector2.x, 1, vector2.y), Quaternion.identity , obstacleparent);
                }
            }
        }
    }

    void SetPlatformPosition( GameObject tile , int row , int col )
    {
        CubeDetails cubeDetails = tile.GetComponent<CubeDetails>();
        if (cubeDetails != null)
        {
            cubeDetails.row = row;
            cubeDetails.col = col;
        }
    }

}


