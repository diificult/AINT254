using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoGun : MonoBehaviour
{
    public GameObject bullet;
    public Light light;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    public float lightLength = 0.1f;
    private bool isFiring = false;


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("In: " + Input.GetKeyDown("10th Axis"));
        if (Input.GetAxis("Fire1")>0)
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
        light.enabled = true;
        Invoke("GunLight", lightLength);
    }


    private void GunLight()
    {
        light.enabled = false;
    }
    private void SetFiring()
    {
        isFiring = false;
    }

}
