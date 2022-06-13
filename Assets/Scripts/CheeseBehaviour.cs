using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBehaviour : InstantiateSliceFood
{
   private void OnEnable() 
    {
        RayKnife.rayKnifeSingalCheeseLaunch += InstantiateSliceFoodCheck;
       
    }

    private void OnDisable() 
    {
        RayKnife.rayKnifeSingalCheeseLaunch -= InstantiateSliceFoodCheck;
        
    }
}
