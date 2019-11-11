using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RespawnSystem : MonoBehaviour
{

    int countdown = 5;
    public List<GameObject> spawnLocations = new List<GameObject>();
    public Text countdownText;
    public GameObject theGun;
    

    //public UnityEvent onDie;
    public UnityEvent onDamaged;
    public void Hit()
    {
        Debug.Log("Hit");
        onDamaged.Invoke();
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        countdownText.enabled = false;
        theGun.SetActive(false);
        countdownText.text = "Respawn in: " + countdown;
        Invoke("CountdownNext", 1);
        
        
    }

    private void CountdownNext()
    {
        countdown--;
        if (countdown == 0)
        {
            GameObject RespawnLocation = new GameObject();
            RespawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
           transform.position = RespawnLocation.transform.position;
            GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<PlayerMovement>().enabled = true;
            countdownText.enabled = true;
            theGun.SetActive(true);
            countdown = 5;
        } else
        {
            countdownText.text = "Respawn in: " + countdown;
            Invoke("CountdownNext", 1);
        }
    }

    IEnumerator GunCountdown()
    {
        yield return new WaitForSeconds(1f);
    }

}
