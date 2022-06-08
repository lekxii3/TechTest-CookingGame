using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSliceFood : MonoBehaviour
{
    public RayKnife rayKnife;
    public GameObject[] sliceFood;
    public int indexSliceFood=0;
    public Transform positionToSpawn;
    public bool currentOneByOne = false;

    private void OnEnable() 
    {
        rayKnife.rayKnifeSingalLaunch += InstantiateSliceFoodCheck;
    }

    private void OnDisable() 
    {
        rayKnife.rayKnifeSingalLaunch -= InstantiateSliceFoodCheck;
    }

    /*private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("ça collide1");  
        if(other.collider.CompareTag("knife"))
        {
            Debug.Log("ça collide");            
            InstantiateSliceFoodCheck();
            indexSliceFood++;
        }
    }*/

    private void InstantiateSliceFoodCheck()
    {        
        currentOneByOne=false;

        if(indexSliceFood < sliceFood.Length-1 && rayKnife.contactFood == true && currentOneByOne == true)
        {
            Instantiate(sliceFood[0],positionToSpawn.position,positionToSpawn.rotation);
        }      

        indexSliceFood++;

        
        

        if(indexSliceFood == sliceFood.Length-1)
        {
            Debug.Log("destroy");
        }
        
    }
}
