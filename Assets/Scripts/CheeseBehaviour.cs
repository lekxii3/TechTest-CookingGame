using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBehaviour : InstantiateSliceFood
{
    /// <summary>
	/// Script Inheritance before InstantiateSliceFood, assigne to cheese prefab for signal if collider with knife prefab
	/// </summary>
   private void OnEnable() 
    {
        RayKnife.rayKnifeSingalCheeseLaunch += InstantiateSliceFoodCheck;
       
    }

    private void OnDisable() 
    {
        RayKnife.rayKnifeSingalCheeseLaunch -= InstantiateSliceFoodCheck;
        
    }
}
