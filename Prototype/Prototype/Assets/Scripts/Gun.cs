using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnAmmoUpdate : UnityEvent<int> { }

public class Gun : MonoBehaviour
{

    //Place for the light to spawn
    public Transform bulletSpawnPoint;
    //Slider that shows reload progress
    public GameObject reloadSlider;
    //Reloading animation for the slider
    public Animator reloadAnim;
    //Partical system for bullets 
    public ParticleSystem particals;
    //Transform component for camera
    public Transform camera;

    //How fast player can shoot
    public float fireRate = 0.4f;
    //How long the light shows for 
    public float lightLength = 0.1f;
    //How long it takes to reload
    public float reloadTime = 1.5f;
    //Is the gun still firing  from last time
    private bool isFiring = false;
    //Current  ammo
    private int ammo = 5;
    //Checks if reloading
    private bool isReloading = false;

    //When the  ammo has been changed can call this
    public OnAmmoUpdate onAmmoUpdate;
    public void Fire()
    {
        if (!isFiring && !isReloading)
        {
            //Sets that it is firing
            isFiring = true;
            //Removes an ammo
            ammo--;
            //Updates the ammo, for the ammo counter UI
            onAmmoUpdate.Invoke(ammo);
            //Stores what was hit
            RaycastHit hit;
            //sends  a raycat out
            if (Physics.Raycast(bulletSpawnPoint.position,
                transform.TransformDirection(camera.forward), out hit, Mathf.Infinity))
            { 
                //Checks to see if it wasnt yourself being shot at
                if (hit.transform.name != transform.name)
                    //Sends  the other object Hit,  Doesnt require receiver so the other object  coudld do nothing with it
                    hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            }
            //Invokes set firing after the rate of fire time passed
            Invoke("SetFiring", fireRate);
            //Plays the particals
            particals.Play();
            //Forces player to reload if they have no ammo
            if (ammo == 0) Reload();
        }
    }

    public void Reload()
    {
        //If ammo is less then 5
        if (ammo < 5)
        {
            //Set the reload slider to be visible
            reloadSlider.SetActive(true);
            //Triggers the reloading animation for the slider
            reloadAnim.SetTrigger("ReloadTrigger");
            //Sets that the gun is realoading so it cant shoot
            isReloading = true;
            //Gets called when the reloading is done
            Invoke("DoneReloading", reloadTime);
        }
    }

    private void DoneReloading()
    {
        //Hides the reloading
        reloadSlider.SetActive(false);
        //Stores that its not reloading anymore
        isReloading = false;
        //Updates ammo
        ammo = 5;
        //Calls to update the ammo
        onAmmoUpdate.Invoke(ammo);
    }
    private void SetFiring()
    {
        //Sets that its no longer firing
        isFiring = false;
    }

}
