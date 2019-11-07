using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RespawnSystem : MonoBehaviour
{

    int countdown = 5;
    public List<GameObject> spawnLocations = new List<GameObject>();

    //public UnityEvent onDie;
    public UnityEvent onDamaged;
    public void Hit()
    {
        Debug.Log("Hit");
        onDamaged.Invoke();
        GetComponent<Renderer>().enabled = false;
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
        } else
        {

            Debug.Log(countdown);
            Invoke("CountdownNext", 1);
        }
    }

}
