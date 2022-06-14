using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSnapTomato : CheckSnapHeritage
{ 
    /// <summary>
	/// Script Inheritance before CheckSnapHeritage, assigne to Stocket Tomato prefab in assemblage for signal if collider with slice tomato prefab
	/// </summary>
    public static event CheckSnapHeritageSignal CheckSnapHeritageSignalLaunch;

    private void OnTriggerEnter(Collider other) 
    {        
       if(other.gameObject.layer == LayerMask.NameToLayer("tomato") && DesactivateSignal==true)
       {  
            CheckSnapHeritageSignalLaunch?.Invoke();
            DesactivateSignal=false;
            Debug.Log(gameObject.name);
       }
    }   
}
