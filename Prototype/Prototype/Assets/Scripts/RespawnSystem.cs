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
    public GameObject body;
    

    public UnityEvent onDamaged;
  //  public void Hit()
  //  {
  //      Debug.Log("Hit: " + transform.name);
  //      onDamaged.Invoke();
  //      body.GetComponent<Renderer>().enabled = false;
  //      GetComponent<BoxCollider>().enabled = false;
  //      GetComponent<PlayerInput>().enabled = false;
  //      countdownText.GetComponent<Animator>().SetTrigger("Countdown");
  //      theGun.SetActive(false);
   //     countdownText.text = "Respawn in: " + countdown;
  //      Invoke("CountdownNext", 1);   
  //  }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit: " + transform.name);
        onDamaged.Invoke();
        body.GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
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

            body.GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<PlayerInput>().enabled = true;            
            GameObject RespawnLocation = new GameObject();
            RespawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
           transform.position = RespawnLocation.transform.position;
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
