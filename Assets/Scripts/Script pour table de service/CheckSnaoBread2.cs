using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSnaoBread2 : CheckSnapHeritage
{
    /// <summary>
	/// Script Inheritance before CheckSnapHeritage, assigne to Stocket bread prefab in assemblage for signal if collider with slice bread prefab
	/// </summary>
   public static event CheckSnapHeritageSignal CheckSnapHeritageSignalLaunch;

    private void OnTriggerEnter(Collider other) 
    {  
       if(other.gameObject.layer == LayerMask.NameToLayer("sliceBread") && DesactivateSignal==true)
       {  
            
            CheckSnapHeritageSignalLaunch?.Invoke();
            DesactivateSignal=false;
            
       }
    }
}
