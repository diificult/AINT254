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
    public GameObject player1PressA;
    public GameObject player2PressA;
    public Canvas controllerInfo;
    public GameObject[] guns = new GameObject[2];
    public GameUI UIController;
    public GameObject IGUI;
    public Slider p1SensSlider;
    private bool p1SensMoved =  false;
    public Slider p2SensSlider;
    private bool p2SensMoved = false;


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
        //Joystick input
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
                player1PressA.SetActive(false);
                
            }
            else if (player1 == input)
            {
                player1Animation.SetTrigger("ButtonPressed");
            }
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
            if (Input.GetAxis(player1 + "Horizontal") > 0.4 && !p1SensMoved)
            {
                p1SensSlider.value += 1;
                p1SensMoved = true;
            }
            
            else if (Input.GetAxis(player1 + "Horizontal") <-0.4 && !p1SensMoved)
            {
                p1SensSlider.value -= 1;
                p1SensMoved = true;
            }else if (Input.GetAxis(player1 + "Horizontal") < 0.4  && Input.GetAxis(player1 + "Horizontal") > -0.4)
            {
                p1SensMoved = false;
            }

        }
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
            pressStart.text = "▶ Press Start ◀";
            if (Input.GetButtonDown("Start"))
            {
                IGUI.gameObject.SetActive(true);
                player1Object.GetComponent<PlayerInput>().enabled = true;
                player1Object.transform.SendMessage("SetControllerNumber", player1, SendMessageOptions.DontRequireReceiver);
                player2Object.GetComponent<PlayerInput>().enabled = true;
                player2Object.transform.SendMessage("SetControllerNumber", player2, SendMessageOptions.DontRequireReceiver);
                player1Object.GetComponent<PlayerInput>().sensitivity = p1SensSlider.value/2;
                player2Object.GetComponent<PlayerInput>().sensitivity = p2SensSlider.value;
                guns[0].GetComponent<Gun>().enabled = true;
                player1Object.GetComponent<RespawnSystem>().Spawn();
                player2Object.GetComponent<RespawnSystem>().Spawn();
                guns[1].GetComponent<Gun>().enabled = true;
                controllerInfo.enabled = false;
                UIController.enabled = true;

            }
        }



    }
}
