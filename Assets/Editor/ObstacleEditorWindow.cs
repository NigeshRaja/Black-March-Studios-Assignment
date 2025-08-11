
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleEditorWindow : EditorWindow
{
    ObstacleGridData obstacleData;
    private bool[,] gridState = new bool[10, 10];
    private const string assetPath = "Assets/Data/ObstacleData.asset";


    [MenuItem("Tools/Obstacle Editor")]
    public static void ShowWindow()
    {
        //show the empty window
        GetWindow<ObstacleEditorWindow>().Show();
    }

    private void OnEnable()
    {
        //Load the scriptable object in the path
        obstacleData = AssetDatabase.LoadAssetAtPath<ObstacleGridData>(assetPath);
        obstacleData.obstacleTiles.Clear();
    }



    private void OnGUI()
    {
        
        EditorGUILayout.LabelField("Tile Blocker Grid", EditorStyles.boldLabel);
        //Generate 10 * 10 toogle button for obstacle
        for (int i = 0; i < 10; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < 10; j++)
            {
                // Draw a toggle button for each tile
                gridState[i,j] = EditorGUILayout.Toggle(gridState[i, j]);
            }
            EditorGUILayout.EndHorizontal();
        }

        if(GUILayout.Button("Generate"))
        {
           
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gridState[i, j])
                    {
                        //When the button is pressed store the all toggle value in gridstate which all are true only stored in scriptabel object obstacletiles
                        
                       
                        obstacleData.obstacleTiles.Add(new Vector2Int(i, j));
                    }
                }
            }
            Close();
        }
        
    }

 
   
}
