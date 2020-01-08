using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAmmo : MonoBehaviour
{

    //Updates the ammo text
    public void  updateAmmo(int Ammo)
    {
        GetComponent<Text>().text = Ammo + " / 5";
    }
}
