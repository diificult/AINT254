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
    public Slider reloadSlider;
    public Animator reloadAnim;

    public float fireRate = 0.4f;
    public float lightLength = 0.1f;
    public float reloadTime = 1.5f;

    private bool isFiring = false;
    private int ammo = 10;
    private bool isReloading = false;

    public OnAmmoUpdate onAmmoUpdate;


    public void Fire()
    {
        if (!isFiring  && !isReloading)
        {
            isFiring = true;
            ammo--;
            onAmmoUpdate.Invoke(ammo);
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.parent.transform.eulerAngles);
            Physics.Raycast(transform.position, transform.parent.transform.eulerAngles, out hit, 100f);
            hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            Debug.Log(hit.collider);
            Debug.Log("Ray hit-->" + hit.transform.gameObject.name + " at " + hit.distance.ToString());
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 10);

          //  Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Invoke("SetFiring", fireRate);
            light.enabled = true;
            Invoke("GunLight", lightLength);
            if (ammo == 0) Reload();
        }
    }

    public void Reload()
    {
        if (ammo < 10)
        {
            reloadSlider.enabled = true;
            reloadAnim.SetTrigger("ReloadTrigger");
            isReloading = true;
            Invoke("DoneReloading", reloadTime);
        }
    }

    private void DoneReloading()
    {
        reloadSlider.enabled = false;
        isReloading = false;
        ammo = 10;
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

}
