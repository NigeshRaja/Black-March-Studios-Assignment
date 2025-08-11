using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="ObstacleData" , menuName = "Scriptable Objects/Obstacle Grid Data", order = 1)]
public class ObstacleGridData : ScriptableObject
{

    //store obstacle grid index
    public List<Vector2Int> obstacleTiles = new List<Vector2Int>();


}
