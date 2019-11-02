using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 500f;
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enters");
        other.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
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
