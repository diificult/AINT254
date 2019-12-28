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

    public Canvas pauseMenu;

    private bool isPaused = false;

    public SceneController sc;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Updatep2Score();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) PauseGame();
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

    private void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            pauseMenu.gameObject.SetActive(false);// = false;
            isPaused = false;
        }  else
        {
            Time.timeScale = 0f;
            pauseMenu.gameObject.SetActive(true);
            isPaused = true;
        }

        Debug.Log("Timescale : " + Time.timeScale);
    }
    

}
