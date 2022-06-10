using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBehaviour : InstantiateSliceFood
{
    // Start is called before the first frame update
    private void OnEnable() 
    {
        RayKnife.rayKnifeSingalTomatoLaunch += InstantiateSliceFoodCheck;
       
    }

    private void OnDisable() 
    {
        RayKnife.rayKnifeSingalTomatoLaunch -= InstantiateSliceFoodCheck;
        
    }
}
