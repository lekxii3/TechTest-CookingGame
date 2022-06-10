using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachPosition : AttachPositionApple
{
    public delegate void DetachPositionSignal();
    public  DetachPositionSignal DetachPositionSignalLaunch;

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log("6");
        if (other.CompareTag("food"))
        {
            Debug.Log("7");
            DetachPositionSignalLaunch?.Invoke();
        }
    }
}
