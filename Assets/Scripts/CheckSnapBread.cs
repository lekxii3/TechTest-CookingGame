using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSnapBread : CheckSnapHeritage
{
   public static event CheckSnapHeritageSignal CheckSnapHeritageSignalLaunch;

    private void OnTriggerEnter(Collider other) 
    {  
       if(other.gameObject.layer == LayerMask.NameToLayer("bread") && DesactivateSignal==true)
       {  
            CheckSnapHeritageSignalLaunch?.Invoke();
            DesactivateSignal=false;
       }
    }
}
