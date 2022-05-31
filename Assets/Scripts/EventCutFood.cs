using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCutFood : MonoBehaviour
{
    // ce script est placer sur un autre script XR stocket et c'est par lui qu'il detecte la collision

    public delegate void EventCut();

    public static event EventCut EventCutLaunch;
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("knife"))
        {
            Debug.Log("coupe legume");
            EventCutLaunch?.Invoke();
        }
    }
}
