using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalCabbage : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("touche");
        }
    }
}
