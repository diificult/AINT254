using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private string moveXAxis;
    private string moveYAxis;
    private string lookXAxis;
    private string lookYAxis;
    private string fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //https://www.youtube.com/watch?v=WIZz2oiZyqU
    void SetControllerNumber(int  number)
    {
        moveXAxis = "J" + number + "Horizontal";
        moveYAxis = "J" + number + "Vertical";
        lookXAxis = "J" + number + "StickHorizontal";
        lookYAxis = "J" + number + "StickVertical";
        fire = "J" + number + "fire";
    }
}
