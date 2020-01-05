using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    //Player controller number
    string player1 = null;
    string player2 = null;
    //Player controller images and animation for those images.
    public Image player1Image;
    Animator player1Animation;
    public Image player2Image;
    Animator player2Animation;
    //Canvas for all the controller setup
    public Canvas controllerInfo;
    //Text for pressing start
    public Text pressStart;
    //Slider for sensitivity
    public Slider p1SensSlider;
    //Stores a check for if the slider been moved.
    private bool p1SensMoved =  false;
    public Slider p2SensSlider;
    private bool p2SensMoved = false;

    //Player game objects
    public GameObject player1Object;
    public GameObject player2Object;
    public GameObject player1PressA;
    public GameObject player2PressA;
    //Play gun game objects
    public GameObject[] guns = new GameObject[2];
    //Controller for the UI
    public GameUI UIController;
    //In-Game UI
    public GameObject IGUI;
    
    void Start()
    {
        //Gets animator components
        player1Animation = player1Image.GetComponent<Animator>();
        player2Animation = player2Image.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Joystick input
        string input = null;
        //Get what input it was
        if (Input.GetButtonDown("J1A")) input = "J1";
        else if (Input.GetButtonDown("J2A")) input = "J2";
        else if (Input.GetButtonDown("J3A")) input = "J3";
        else if (Input.GetButtonDown("J4A")) input = "J4";
        //Checks if there was an imput
        if (input != null)
        {
            //Checks to see if player 1 is not assigned to already AND the controller is not assigned to the second player
            //The second part is just error handling just incase there was a bug that caused issue
            //and make future development easier if i was to deal with disconnected controllers
            if (player1 == null && player2 != input)
            {
                //Player 1's input gets set to this controller
                player1 = input;
                //Makes the controller green to give a visual response.
                player1Image.color = Color.green;
                //Removes the press A text
                player1PressA.SetActive(false);
                
            }
            //If the input is already assigned to player 1
            else if (player1 == input)
            {
                //Play an animation that moves the controller up and down
                player1Animation.SetTrigger("ButtonPressed");
            }
            //Checks to see if player two is empty  (so a third controller cant take over) and the input isnt already assigned to player 1
            //Second part is more error handling dealing with any bugs that may occour
            else if (player2 == null && player1 != input)
            {
                player2 = input;
                player2Image.color = Color.green;
                player2PressA.SetActive(false);
            } 
            else if (player2 == input)   
            {
                player2Animation.SetTrigger("ButtonPressed");
            }
        }
        //Checks this first to make sure there is no error
        if (player1 != null)
        {
            //Checks if the player has moved the  stick by more then 0.4 && checks if the stick hasnt moved already
            //in this movement.
            //The stick must return past the 0.4 mark to then move to the left
            if (Input.GetAxis(player1 + "Horizontal") > 0.4 && !p1SensMoved)
            {
                //Value increases by 1
                p1SensSlider.value += 1;
                //The stick has been moved
                p1SensMoved = true;
            }
            //Checks to see if the stick has been moved less then -0.4
            else if (Input.GetAxis(player1 + "Horizontal") <-0.4 && !p1SensMoved)
            {
                p1SensSlider.value -= 1;
                p1SensMoved = true;
                //If the stick has been returned to between these values then reset the stick moved bool
            }else if (Input.GetAxis(player1 + "Horizontal") < 0.4  && Input.GetAxis(player1 + "Horizontal") > -0.4)
            {
                p1SensMoved = false;
            }

        }
        //Does the same but with the second player
        if (player2 != null)
        {
            if (Input.GetAxis(player2 + "Horizontal") > 0.4 && !p2SensMoved)
            {
                p2SensSlider.value += 1;
                p2SensMoved = true;
            }

            else if (Input.GetAxis(player2 + "Horizontal") < -0.4 && !p2SensMoved)
            {
                p2SensSlider.value -= 1;
                p2SensMoved = true;
            }
            else if (Input.GetAxis(player2 + "Horizontal") < 0.4 && Input.GetAxis(player2 + "Horizontal") > -0.4)
            {
                p2SensMoved = false;
            }

        }


        //Once both players are in - Start Game
        if (player1 != null && player2 != null)
        {
            //Lets the player know that they can start the game
            pressStart.text = "▶ Press Start ◀";
            if (Input.GetButtonDown("Start"))
            {
                //Brings up the game GUI
                IGUI.gameObject.SetActive(true);
                //Enables the script for player input
                player1Object.GetComponent<PlayerInput>().enabled = true;
                //Tells the player  object what their controller number they  have been assigned to
                player1Object.transform.SendMessage("SetControllerNumber", player1, SendMessageOptions.DontRequireReceiver);
                player2Object.GetComponent<PlayerInput>().enabled = true;
                player2Object.transform.SendMessage("SetControllerNumber", player2, SendMessageOptions.DontRequireReceiver);
                //Sets the sensitivity to the assigned value
                player1Object.GetComponent<PlayerInput>().sensitivity = p1SensSlider.value/2;
                player2Object.GetComponent<PlayerInput>().sensitivity = p2SensSlider.value/2;
                //Enable players guns
                guns[0].GetComponent<Gun>().enabled = true;
                guns[1].GetComponent<Gun>().enabled = true;
                //Spawns the player in their spawn possition
                player1Object.GetComponent<RespawnSystem>().Spawn();
                player2Object.GetComponent<RespawnSystem>().Spawn();
                
                //Disables the controller info UI
                controllerInfo.enabled = false;
                //Enables the UI controller 
                UIController.enabled = true;

            }
        }



    }
}
