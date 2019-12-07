using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static int winner;




    //Unimplemented - Will  be used once main menu created
    public void StartGame()
    {
        SceneManager.LoadScene("Map 1");
    }

    public void EndGame(int w)
    {
        winner = w;
        SceneManager.LoadScene("End Screen");
        Cursor.lockState = CursorLockMode.None;
    }

    public int GetWinner()
    {
        return winner;
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
