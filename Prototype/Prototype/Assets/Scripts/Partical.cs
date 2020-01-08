using UnityEngine;

public class Partical : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    private bool isStarted = false;

    private void Update()
    {
        //Doesnt move the partical system unless its not emitting.
        if (!GetComponent<ParticleSystem>().isEmitting)
        {
            //Moves the partical system to bullet spawn point position
            Vector3 playerPos = bulletSpawnPoint.transform.position;
            transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
            //Moves the rotation to the bullet spawn rotation

            transform.rotation = bulletSpawnPoint.transform.rotation;
        }

    }


}
