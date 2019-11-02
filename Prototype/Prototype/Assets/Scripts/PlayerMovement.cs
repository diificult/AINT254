using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    Rigidbody rigidbody;
    public float speed;
    public float rotationSpeed;
    public Camera c;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        movement = c.transform.TransformDirection(movement);
        movement.y = 0;
 //       rigidbody.AddForce(movement);
        rigidbody.velocity = movement;
    }

}
