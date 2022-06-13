using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechSnapCheese : CheckSnapHeritage
{
    public static event CheckSnapHeritageSignal CheckSnapHeritageSignalLaunch;

    private void OnTriggerEnter(Collider other) 
    {    
       if(other.gameObject.layer == LayerMask.NameToLayer("cheese") && DesactivateSignal==true)
       {    
            CheckSnapHeritageSignalLaunch?.Invoke();
            DesactivateSignal=false;
       }
    }
}
