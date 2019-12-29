using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{


    public void Add()
    {
        int text = int.Parse(GetComponent<Text>().text);
        if (text < 99)
            text++;
        GetComponent<Text>().text = text.ToString();
        

    }
    public void Subtract()
    {
        int text = int.Parse(GetComponent<Text>().text);
        if (text > 1)
            text--;
        GetComponent<Text>().text = text.ToString();


    }

}
