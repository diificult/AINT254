using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 500f;
    public GameObject camera;
    

    // Start is called before the first frame update
    void Start()
    {
     //   Vector3 m = new Vector3();
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter2D(Collider other)
    { 
        Die();
    }
    private void OnBecameInvisible()
    {
        Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }

}
