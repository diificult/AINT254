using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    //All controls 
    private string moveXAxis;
    private string moveYAxis;
    private string lookXAxis;
    private string lookYAxis;
    private string fire;
    private string reload;

    public Camera c;
    public Gun gun;
    public CharacterController cc;
    //Empty game object at the bottom of the player to check if there is ground below it
    public Transform GroundChecker;
    bool isGrounded;
    public LayerMask groundMask;
    //Velocity
    Vector3 v;
   

    public float speed;
    public float sensitivity;



    // Update is called once per frame
    void Update()
    {
        //Checks if it is grounded below using a sphere that sees if there is any object with that layer in the radius
        isGrounded = Physics.CheckSphere(GroundChecker.position, 0.4f, groundMask);
        if (isGrounded && v.y == 0) v.y = -2f;
        //Movement
        Vector3 movement = Input.GetAxis(moveXAxis) * c.transform.right + Input.GetAxis(moveYAxis) *c.transform.forward;
        cc.Move(movement * speed *Time.deltaTime);
        v.y = v.y + (-9.81f * Mathf.Pow(Time.deltaTime,2));
        cc.Move(v);
        

        //Camera
        Vector3 r = new Vector3(-Input.GetAxis(lookYAxis), Input.GetAxis(lookXAxis), 0) * sensitivity;
        float y = -Input.GetAxis(lookYAxis) * sensitivity;
        float x = Input.GetAxis(lookXAxis) * sensitivity;
        y = Mathf.Clamp(y, -45.0f, 45.0f);
        c.transform.eulerAngles += new Vector3(y, x, 0);
        if (c.transform.eulerAngles.x > 35 && c.transform.eulerAngles.x < 90) c.transform.eulerAngles = new Vector3(35f, c.transform.eulerAngles.y, 0);
        if (c.transform.eulerAngles.x < 325 && transform.eulerAngles.x > 90) c.transform.eulerAngles = new Vector3(325, c.transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(0, c.transform.rotation.y, 0);
        

        //Gun
        if (Input.GetAxis(fire) > 0)
        {
            gun.Fire();
        }
        if (Input.GetButtonDown(reload)) gun.Reload();
    }


    //https://www.youtube.com/watch?v=WIZz2oiZyqU this was used to take inspiration for the design for this set of code, but all been coded in my own way from the other class.
    // The game controller sends the number input that the controller is for this player. E.g. Player one might be using controller 3 (If there was
    // 3 or more controllers plugged in) Also prevents buggy controllers that may be on controller 4 when there is only 1 plugged in
    void SetControllerNumber(string number)
    {
        moveXAxis = number + "Horizontal";
        moveYAxis = number + "Vertical";
        lookXAxis = number + "StickHorizontal";
        lookYAxis = number + "StickVertical";
        fire = number + "Fire";
        reload = number + "Reload";
    }
}
