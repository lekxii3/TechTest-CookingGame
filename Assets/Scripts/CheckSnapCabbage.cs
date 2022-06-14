using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSnapCabbage : CheckSnapHeritage
{
    /// <summary>
	/// Script Inheritance before CheckSnapHeritage, assigne to Stocket cabbage prefab in assemblage for signal if collider with slice cabbage prefab
	/// </summary>
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
