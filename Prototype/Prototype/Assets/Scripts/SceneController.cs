using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static int winner;
    private static int firstTo;

    [SerializeField]
    private Text firstToText;

    public void StartGame()
    {
        SceneManager.LoadScene("_japanese");
        firstTo = int.Parse(firstToText.text);
    }

    public void EndGame(int w)
    {
        winner = w;
        SceneManager.LoadScene("_End Screen");
        Cursor.lockState = CursorLockMode.None;
    }

    //Only currently imlements for end screen. Not yet for pause menu
    public void MainMenu()
    {
        SceneManager.LoadScene("_Main Menu");
        Cursor.lockState = CursorLockMode.None;
    }


    public int GetWinner()
    {
        return winner;
    }
    public int GetFirstTo()
    {
        return firstTo;
    }


    public void ExitGame()
    {
        Application.Quit(0);
    }
}
