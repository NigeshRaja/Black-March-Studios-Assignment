
using UnityEngine;


public class PlatformRaycast : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PlayerMovement playerMovement;
    GameManager gameManager;
    

    private void Start()
    {
        gameManager = GameManager.instance;
    }


    void Update()
    {
        RaycastTile();
    }

    void RaycastTile()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Casting a ray from the main camera  at mouse postion thal interact with only the certain layer
        if(Physics.Raycast(ray, out hit ,Mathf.Infinity ,layerMask))
        {
            GameObject tile = hit.collider.gameObject;
            if(tile != null)
            {
               //If the tile hit the call these method to display the  index number in Ui
                GetTilePosition(tile);
            }

        }

  
    }


    void GetTilePosition(GameObject hitObject)
    {
        //Get the detail script in the hitobject
        CubeDetails cubeDetails = hitObject.GetComponent<CubeDetails>();
        if (cubeDetails != null)
        {
            //If cube details present then diplay the index in ui;
            gameManager.ShowTilePostition(cubeDetails.row, cubeDetails.col);
            //Check whether the mouse is pressed or not
            if (Input.GetMouseButtonDown(0) && !playerMovement.isMoving)
            {
                //If mouse is pressed the player move to the clicked position so need to store the clicked posiyion in the playermovement script
                playerMovement.clickPosition = new Vector2Int(cubeDetails.row, cubeDetails.col);
                playerMovement.isMouseClicked = true;

            }
        }

        
    }
}
