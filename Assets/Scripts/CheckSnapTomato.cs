using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSnapTomato : CheckSnapHeritage
{ 
    public static event CheckSnapHeritageSignal CheckSnapHeritageSignalLaunch;

    private void OnTriggerEnter(Collider other) 
    {        
       if(other.gameObject.layer == LayerMask.NameToLayer("tomato") && DesactivateSignal==true)
       {  
            CheckSnapHeritageSignalLaunch?.Invoke();
            DesactivateSignal=false;
       }
    }   
}
