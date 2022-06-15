using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechSnapCheese : CheckSnapHeritage
{
    /// <summary>
	/// Script Inheritance before CheckSnapHeritage, assigne to Stocket cheese prefab in assemblage for signal if collider with slice cheese prefab
	/// </summary>
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
