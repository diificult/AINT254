using UnityEngine;

public class Partical : MonoBehaviour
{
    public GameObject player;
    private bool isStarted = false;

    private void Update()
    {
        if (GetComponent<ParticleSystem>().isEmitting && !isStarted)
        {
            isStarted = true;
            Vector3 playerPos = player.transform.position;
            transform.position = new Vector3(playerPos.x + 0.35f  +0.09f, playerPos.y - 0.29f +1.75f, playerPos.z + 0.47f  + 0.14f);
            transform.rotation = player.transform.rotation;
        }
        else if (!GetComponent<ParticleSystem>().isEmitting)
        {
            isStarted = false;
        }

    }


}
