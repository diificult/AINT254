using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHTP : MonoBehaviour
{
    [SerializeField]
    private RawImage HTP;

    public void Show()
    {
        HTP.gameObject.SetActive(true);
    }

    public void Hide()
    {
        HTP.gameObject.SetActive(false);
    }
    
}
