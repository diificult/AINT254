using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    private bool isFiring = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }

    }

    private void Fire()
    {
        isFiring = true;
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Invoke("SetFiring", fireRate);
    }

    private void SetFiring()
    {
        isFiring = false;
    }


}
