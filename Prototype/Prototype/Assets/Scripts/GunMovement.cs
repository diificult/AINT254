using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = camera.transform.position;
        Quaternion camRotation = camera.transform.rotation;
        
        camPos.z += 0.3f;
        camPos.x += 0.3f;
        transform.position = camPos;
        transform.rotation = camRotation ;
    }
}
