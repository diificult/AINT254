using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RespawnSystem : MonoBehaviour
{
    //public UnityEvent onDie;
    public UnityEvent onDamaged;
    public void Hit()
    {
        Debug.Log("Hit");
        onDamaged.Invoke();

    }

}
