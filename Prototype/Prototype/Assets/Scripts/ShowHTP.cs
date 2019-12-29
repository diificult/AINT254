using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHTP : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void Show()
    {
        menu.gameObject.SetActive(true);
    }

    public void Hide()
    {
        menu.gameObject.SetActive(false);
    }
    
}
