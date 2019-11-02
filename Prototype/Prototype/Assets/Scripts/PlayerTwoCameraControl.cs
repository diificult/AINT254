using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCameraControl : MonoBehaviour
{
    public int sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // Quaternion rotation = Quaternion.Euler(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
        Vector3 r = new Vector3(-Input.GetAxis("CRY"), Input.GetAxis("CRX"), 0) * sensitivity;

       // Debug.Log("y " + Input.GetAxis("CRY") + ", x " + Input.GetAxis("CRX"));

        float y = -Input.GetAxis("CRY") * sensitivity;
        float x = Input.GetAxis("CRX") * sensitivity;
        y = Mathf.Clamp(y, -45.0f, 45.0f);
        //   Debug.Log(transform.localEulerAngles.x);

        transform.localEulerAngles += new Vector3(y, x, 0);
        if (transform.localEulerAngles.x > 45 && transform.localEulerAngles.x < 90) transform.localEulerAngles = new Vector3(45f, transform.localEulerAngles.y, 0);
        if (transform.localEulerAngles.x < 315 && transform.localEulerAngles.x > 90) transform.localEulerAngles = new Vector3(315, transform.localEulerAngles.y, 0);

    }
}
