using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{

    string player1 = null;
    string player2 = null;
    public Image player1Image;
    Animator player1Animation;
    public Image player2Image;
    Animator player2Animation;
    public GameObject player1Object;
    public GameObject player2Object;
    public Canvas controllerInfo;

    public Text pressStart;

    // Start is called before the first frame update
    void Start()
    {
        player1Animation = player1Image.GetComponent<Animator>();
        player2Animation = player2Image.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets if there is a controller input. Efficient method to add additional joysticks.
        string input = null;
        if (Input.GetButtonDown("J1A")) input = "J1";
        else if (Input.GetButtonDown("J2A")) input = "J2";
        else if (Input.GetButtonDown("J3A")) input = "J3";
        else if (Input.GetButtonDown("J4A")) input = "J4";
        if (input != null)
        {
            if (player1 == null && player2 != input)
            {
                player1 = input;
                player1Image.color = Color.green;
            }
            else if (player1 == input)
            {
                player1Animation.SetTrigger("ButtonPressed");
            }
            else if (player2 == null && player1 != input)
            {
                player2 = input;
                player2Image.color = Color.green;
            } 
            else if (player2 == input)   
            {
                player2Animation.SetTrigger("ButtonPressed");
            }
        }


        ////if (Input.GetButtonDown("J1A"))
        ////{
        ////    Debug.Log("j2a, player1 = " + player1 + ", player2 = " + player2);
        ////    if (player1 == 0 && player2 != 1)
        ////    {
        ////        player1 = 1;
        ////        player1Image.color = Color.green;
        ////    }
        ////    else if (player1 == 1)
        ////    {
        ////        player1Animation.SetTrigger("ButtonPressed");
        ////    }
        ////    else if (player2 == 0 && player1 != 1)
        ////    {
        ////        player2 = 1;
        ////        player2Image.color = Color.green;
        ////    }
        ////    else if (player2 == 1)
        ////    {
        ////        player2Animation.SetTrigger("ButtonPressed");
        ////    }
        ////}
        ////if (Input.GetButtonDown("J2A"))
        ////{

        ////    Debug.Log("j2a, player1 = " + player1 + ", player2 = " + player2);
        ////    if (player1 == 0 && player2 != 2)
        ////    {
        ////        player1 = 2;
        ////        player1Image.color = Color.green;
        ////    }
        ////    else if (player1 == 2)
        ////    {
        ////        player1Animation.SetTrigger("ButtonPressed");
        ////    }
        ////    else if (player2 == 0 && player1 != 2)
        ////    {
        ////        player2 = 2;
        ////        player2Image.color = Color.green;
        ////    }
        ////    else if (player2 == 2)
        ////    {
        ////        player2Animation.SetTrigger("ButtonPressed");
        ////    }
        ////}
        ////if (Input.GetButtonDown("J3A")) Debug.Log("j3");
        ////if (Input.GetButtonDown("J4A")) Debug.Log("j4");
        if (player1 != null && player2 != null)
        {
            pressStart.enabled = true;
            if (Input.GetButtonDown("Start"))
            {
                player1Object.GetComponent<PlayerInput>().enabled = true;
                player1Object.transform.SendMessage("SetControllerNumber", player1, SendMessageOptions.DontRequireReceiver);
                player2Object.GetComponent<PlayerInput>().enabled = true;
                player2Object.transform.SendMessage("SetControllerNumber", player2, SendMessageOptions.DontRequireReceiver);
            }
        }

    }
}
