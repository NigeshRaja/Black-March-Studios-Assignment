using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TMP_Text indexUi;

    private void Awake()
    {
        instance = this;
    }

    public void ShowTilePostition(int row , int col)
    {
       indexUi.text = row + "," + col;
    }
}
