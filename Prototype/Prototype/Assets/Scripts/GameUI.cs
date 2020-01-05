using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //UI Text for the score
    public Text p1ScoreText;
    public Text p2ScoreText;

    //Stores the current score
    public int p1Score = 0;
    public int p2Score = 0;

    //Pause screen
    public Canvas pauseMenu;
    //Stores if the game is paused
    private bool isPaused = false;

    //Scene controller that  changes the scene
    public SceneController sc;

    //Stores what the score is first  to
    private int firstTo;



    private void Update()
    {
        
        //Gets if the escape key or either pause button is pressed
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) PauseGame();
    }


    
    private void OnEnable()
    {
        //Gets first to get to from the scene controller
        firstTo = sc.GetFirstTo();
    }

    public void Updatep1Score()
    {
        //Increases the score by 1
        p1Score++;
        //Sets the text to the new score
        p1ScoreText.text = "" + p1Score;
        //If player achieves winning score
        if  (p1Score == firstTo)
        {
            //Take the game to the end screen
            sc.EndGame(1);
        }
    }
    public void Updatep2Score()
    {
        p2Score++;
        p2ScoreText.text = "" + p2Score;
        if (p2Score == firstTo)
        {
            sc.EndGame(2);
        }
    }

    private void PauseGame()
    {
        //Checks to see if the game is paused or not 
        if (isPaused)
        {
            //Brings the time scale back up
            Time.timeScale = 1f;
            //Removes pause  menu
            pauseMenu.gameObject.SetActive(false);
            //Store that the  game has been unpaused
            isPaused = false;
        }  else
        {
            Time.timeScale = 0f;
            pauseMenu.gameObject.SetActive(true);
            isPaused = true;
        }

    }
    

}
