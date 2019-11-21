using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPlace : MonoBehaviour
{


    public Camera c;

    // Update is called once per frame
    void Update()
    {
        Vector3 crosshairPos = new Vector3(c.transform.position.x +(c.scaledPixelWidth / 2), c.transform.position.x +  (c.scaledPixelHeight/2),0);
        transform.position = crosshairPos;
    }
}
