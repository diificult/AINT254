using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{

    //Called when the value up button is pressed
    public void Add()
    {
        //Gets the current value of the text
        int text = int.Parse(GetComponent<Text>().text);
        //Checks to see if the value is less than 99 as this will be the max, if so one is added to the value
        if (text < 99)
            text++;
        //Gets the text component where this script is placed and places the new value
        GetComponent<Text>().text = text.ToString();
    }
    //Called when the value down button  is pressed
    public void Subtract()
    {
        int text = int.Parse(GetComponent<Text>().text);
        //Checks to see if the value is greater than 1 as this will be the min, if so one is added to the value
        if (text > 1)
            text--;
        GetComponent<Text>().text = text.ToString();


    }

}
