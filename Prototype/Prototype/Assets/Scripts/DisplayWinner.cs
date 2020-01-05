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
        //Gets the winner that was moved between scenes
        int winner = GetComponent<SceneController>().GetWinner();
        //Gets if player 1 was the winner
        if (winner == 1)
        {

            //Sets the font colour to the red
            winnerText.color = new Color(180f / 255.0f, 16f / 255.0f, 19f / 255.0f);//B41013
            //Sets the text to player one
            winnerText.text = "Player One";
            
            
        }
        else if (winner == 2)
        {
            winnerText.color = new Color(26f / 255.0f, 61f / 255.0f, 178f / 255.0f);//1A3DB2
            winnerText.text = "Player Two";
            
            
        }
    }


}
