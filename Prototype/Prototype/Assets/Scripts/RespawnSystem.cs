using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class RespawnSystem : MonoBehaviour
{

    //Count down til respawn
    int countdown = 5;
    public List<GameObject> spawnLocations = new List<GameObject>();
    public GameObject originSpawn;
    public Text countdownText;
    public GameObject theGun;
    

    public UnityEvent onDamaged;
    public void Hit()
    {
        Debug.Log("Hit: " + transform.name);
        onDamaged.Invoke();
        GetComponent<Renderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;
        countdownText.GetComponent<Animator>().SetTrigger("Countdown");
        theGun.SetActive(false);
        countdownText.text = "Respawn in: " + countdown;
        Invoke("CountdownNext", 1);
        
        
    }

   

    private void CountdownNext()
    {
        countdown--;
        if (countdown == 0)
        {
            //Spawns and re-enables the player
            GameObject RespawnLocation = new GameObject();
            RespawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
           transform.position = RespawnLocation.transform.position;
            GetComponent<Renderer>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<PlayerInput>().enabled = true;
            countdownText.GetComponent<Animator>().SetTrigger("GoOut");
            theGun.SetActive(true);
            countdown = 5;
        } else
        {
            // Recurrsion is used until the countdown is done
            countdownText.text = "Respawn in: " + countdown;
            Invoke("CountdownNext", 1);
        }
    }

    public void Spawn()
    {
        transform.position = originSpawn.transform.position;
    }
}
