using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class OnAmmoUpdate : UnityEvent<int> { }

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Light light;
    public Transform bulletSpawnPoint;
    public GameObject reloadSlider;
    public Animator reloadAnim;
    public ParticleSystem particals;

    public float fireRate = 0.4f;
    public float lightLength = 0.1f;
    public float reloadTime = 1.5f;

    private bool isFiring = false;
    private int ammo = 5;
    private bool isReloading = false;

    public OnAmmoUpdate onAmmoUpdate;

    private float lastFired;

     void OnEnable()
    {
        Debug.Log("Started");
        lastFired = Time.time;
        StartCoroutine("LastFired");
    }

    public void Fire()
    {
        if (!isFiring  && !isReloading)
        {
            isFiring = true;
            ammo--;
            onAmmoUpdate.Invoke(ammo);
            RaycastHit hit;
            int mask = 1 << 5;
            mask = ~mask;

            // Delete this for better performance!
          //  Debug.DrawRay(bulletSpawnPoint.position, transform.TransformDirection(Vector3.forward) * 100 /* * hit.distance*/, Color.yellow, 10);

            if (Physics.Raycast(bulletSpawnPoint.position,
                /*bulletSpawnPoint.*/transform.TransformDirection(/*bulletSpawnPoint.transform.*/Vector3.forward), out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
            {
            //    Debug.Log(hit.collider);
             //   Debug.Log("Ray hit-->" + hit.transform.gameObject.name + " at " + hit.distance.ToString());
             //   if (hit.transform.gameObject.layer == LayerMask.GetMask("Player"))
             if (hit.transform.name != transform.name)
                    hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            }
            
          //  Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Invoke("SetFiring", fireRate);
            //light.enabled = true;
            //Invoke("GunLight", lightLength);
            particals.Play();
            if (ammo == 0) Reload();
        }
    }

    public void Reload()
    {
        if (ammo < 5)
        {
            reloadSlider.SetActive(true);
            reloadAnim.SetTrigger("ReloadTrigger");
            isReloading = true;
            Invoke("DoneReloading", reloadTime);
        }
    }

    private void DoneReloading()
    {
        reloadSlider.SetActive(false);
        isReloading = false;
        ammo = 5;
        onAmmoUpdate.Invoke(ammo);
    }

    private void GunLight()
    {
        light.enabled = false;
    }
    private void SetFiring()
    {
        isFiring = false;
    }
    IEnumerator CheckFire()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Last Fired: " + lastFired + ", Difference: " + (Time.time - lastFired));
        StartCoroutine("LastFired");
    }

}
