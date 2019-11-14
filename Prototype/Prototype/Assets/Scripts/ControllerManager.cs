using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{

    int player1 = 0;
    int player2 = 0;
    public Image player1Image;
    Animator player1Animation;
    public Image player2Image;
    Animator player2Animation;

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
        if (Input.GetButtonDown("J1A"))
        {
            Debug.Log("j2a, player1 = " + player1 + ", player2 = " + player2);
            if (player1 == 0 && player2 != 1)
            {
                player1 = 1;
                player1Image.color = Color.green;
            }
            else if (player1 == 1)
            {
                player1Animation.SetTrigger("ButtonPressed");
            }
            else if (player2 == 0 && player1 != 1)
            {
                player2 = 1;
                player2Image.color = Color.green;
            }
            else if (player2 == 1)
            {
                player2Animation.SetTrigger("ButtonPressed");
            }
        }
        if (Input.GetButtonDown("J2A"))
        {
            
            Debug.Log("j2a, player1 = " + player1 + ", player2 = " + player2);
            if (player1 == 0 && player2 != 2)
            {
                player1 = 2;
                player1Image.color = Color.green;
            }
            else if (player1 == 2)
            {
                player1Animation.SetTrigger("ButtonPressed");
            }
            else if (player2 == 0 && player1 != 2)
            {
                player2 = 2;
                player2Image.color = Color.green;
            }
            else if (player2 == 2)
            {
                player2Animation.SetTrigger("ButtonPressed");
            }
        }
        if (player1 > 0 && player2 > 0)
        {
            pressStart.enabled = true;
            if (Input.GetButtonDown("Start"))
            {

            }
        }

    }
}
