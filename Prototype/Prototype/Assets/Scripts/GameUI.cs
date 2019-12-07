using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public Text p1ScoreText;
    public Text p2ScoreText;

    public int p1Score = 0;
    public int p2Score = 0;

    public SceneController sc;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Updatep2Score();
        }
    }

    public void Updatep1Score()
    {
        p1Score++;
        p1ScoreText.text = "" + p1Score;
        if  (p1Score == 7)
        {
            sc.EndGame(1);
        }
    }
    public void Updatep2Score()
    {
        p2Score++;
        p2ScoreText.text = "" + p2Score;
        if (p2Score == 7)
        {
            sc.EndGame(2);
        }
    }

}
