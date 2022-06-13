using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSnapCabbage : CheckSnapHeritage
{
    public static event CheckSnapHeritageSignal CheckSnapHeritageSignalLaunch;

    private void OnTriggerEnter(Collider other) 
    {    
       if(other.gameObject.layer == LayerMask.NameToLayer("cabbage") && DesactivateSignal==true)
       {           
            CheckSnapHeritageSignalLaunch?.Invoke();
            DesactivateSignal=false;
       }
    }   
}
