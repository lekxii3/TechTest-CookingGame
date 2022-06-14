using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBehaviour : InstantiateSliceFood
{
    /// <summary>
	/// Script Inheritance before InstantiateSliceFood, assigne to bread prefab for signal if collider with knife prefab
	/// </summary>
    private void OnEnable() 
    {
        RayKnife.rayKnifeSingalBreadLaunch += InstantiateSliceFoodCheck;
       
    }

    private void OnDisable() 
    {
        RayKnife.rayKnifeSingalBreadLaunch -= InstantiateSliceFoodCheck;
        
    }
}
