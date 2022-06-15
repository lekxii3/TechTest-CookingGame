using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceBehaviour : MonoBehaviour
{
   private void OnEnable() 
    {
        LevelManagerPackSetActived.LevelManagerPackSetActivedSignalLaunch += DestroyItself;
    }
    private void OnDisable() 
    {
        LevelManagerPackSetActived.LevelManagerPackSetActivedSignalLaunch -= DestroyItself;
    }

    private void DestroyItself()
    {
        Destroy(this.gameObject);
    }
}
