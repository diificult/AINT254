using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenuScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    //Hides and shows the settings and how to play on the main menu

    public void Show()
    {
        menu.gameObject.SetActive(true);
    }

    public void Hide()
    {
        menu.gameObject.SetActive(false);
    }
    
}
