using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinner : MonoBehaviour
{
    [SerializeField]
    private Text winnerText;
    void Start()
    {
        int winner = GetComponent<SceneController>().GetWinner();
        if (winner == 1)
        {
            winnerText.color = new Color(180f / 255.0f, 16f / 255.0f, 19f / 255.0f);
            winnerText.text = "Player One";
            //B41013
            
        }
        else if (winner == 2)
        {
            winnerText.color = new Color(26f / 255.0f, 61f / 255.0f, 178f / 255.0f);
            winnerText.text = "Player Two";
            //1A3DB2
            
        }
    }


}
