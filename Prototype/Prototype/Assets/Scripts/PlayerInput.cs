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

    private Rigidbody rigidbody;

    public float speed;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(moveXAxis), 0, Input.GetAxis(moveYAxis)) * speed;
        rigidbody.velocity = movement;
        Vector3 r = new Vector3(-Input.GetAxis(lookYAxis), Input.GetAxis(lookXAxis), 0) * sensitivity;

        float y = -Input.GetAxis(lookYAxis)* sensitivity;
        float x = Input.GetAxis(lookXAxis) * sensitivity;
        y = Mathf.Clamp(y, -45.0f, 45.0f);

        transform.localEulerAngles += new Vector3(y, x, 0);
        if (transform.localEulerAngles.x > 45 && transform.localEulerAngles.x < 90) transform.localEulerAngles = new Vector3(45f, transform.localEulerAngles.y, 0);
        if (transform.localEulerAngles.x < 315 && transform.localEulerAngles.x > 90) transform.localEulerAngles = new Vector3(315, transform.localEulerAngles.y, 0);

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
