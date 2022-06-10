using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBehaviour : InstantiateSliceFood
{
    // Start is called before the first frame update
    private void OnEnable() 
    {
        RayKnife.rayKnifeSingalBreadLaunch += InstantiateSliceFoodCheck;
       
    }

    private void OnDisable() 
    {
        RayKnife.rayKnifeSingalBreadLaunch -= InstantiateSliceFoodCheck;
        
    }
}
