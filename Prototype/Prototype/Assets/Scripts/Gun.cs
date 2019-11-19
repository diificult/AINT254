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

    public float fireRate = 0.4f;
    public float lightLength = 0.1f;
    public float reloadTime = 1.5f;

    private bool isFiring = false;
    private int ammo = 10;
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
            
            if (Physics.Raycast(bulletSpawnPoint.position, transform.parent.transform.eulerAngles, out hit, Mathf.Infinity,  mask))
            {
                Debug.Log(hit.collider);
                Debug.Log("Ray hit-->" + hit.transform.gameObject.name + " at " + hit.distance.ToString());
             //   if (hit.transform.gameObject.layer == LayerMask.GetMask("Player"))
                    hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow, 10);
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
    IEnumerator CheckFire()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Last Fired: " + lastFired + ", Difference: " + (Time.time - lastFired));
        StartCoroutine("LastFired");
    }

}
