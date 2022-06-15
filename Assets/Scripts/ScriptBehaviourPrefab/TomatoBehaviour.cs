using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBehaviour : InstantiateSliceFood
{
    /// <summary>
	/// Script Inheritance before InstantiateSliceFood, assigne to tomato prefab for signal if collider with knife prefab
	/// </summary>
    private void OnEnable() 
    {
        RayKnife.rayKnifeSingalTomatoLaunch += InstantiateSliceFoodCheck;
       
    }

    private void OnDisable() 
    {
        RayKnife.rayKnifeSingalTomatoLaunch -= InstantiateSliceFoodCheck;
        
    }
}
