using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private string moveXAxis;
    private string moveYAxis;
    private string lookXAxis;
    private string lookYAxis;
    private string fire;
    private string reload;
    public Camera c;


    Rigidbody rigidbody;
    public Gun gun;
    public CharacterController cc;
    public Transform GroundChecker;
    bool isGrounded;
    public LayerMask groundMask;
    Vector3 v;
   

    public float speed;
    public float sensitivity;

    // Start is called before the first frame update
    void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Old Movement

        // Vector3 movement = new Vector3(Input.GetAxis(moveXAxis), rigidbody.velocity.y, Input.GetAxis(moveYAxis)) * speed;
        //   movement = c.transform.TransformDirection(movement);
        //   movement.y = rigidbody.velocity.y + (-9.81f * Time.deltaTime);
        //  rigidbody.velocity = movement;

        isGrounded = Physics.CheckSphere(GroundChecker.position, 0.4f, groundMask);
        if (isGrounded && v.y == 0) v.y = -2f;
        Vector3 movement = Input.GetAxis(moveXAxis) * transform.right + Input.GetAxis(moveYAxis) *transform.forward;
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
        // body.rotation =  new Quaternion(body.rotation.x, c.transform.eulerAngles.y, body.rotation.z, 0);
        transform.Rotate(Vector3.up * Input.GetAxis(lookXAxis) * sensitivity *2);

        //Gun
        if (Input.GetAxis(fire) > 0)
        {
            gun.Fire();
        }
        if (Input.GetButtonDown(reload)) gun.Reload();
    }


    //https://www.youtube.com/watch?v=WIZz2oiZyqU this was used to take inspiration for the design, but all been coded in my own way.
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
