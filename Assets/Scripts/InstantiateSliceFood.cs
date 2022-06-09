using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSliceFood : MonoBehaviour
{
    public RayKnife rayKnife;
    public AttachPositionApple attachPositionApple;
    public GameObject[] sliceFood;
    public int indexSliceFood=0;
    public Transform positionToSpawn;
    public Transform AttachPositionApple;
    public bool currentOneByOne = false;
    private bool positionOccuped = false;

    private void OnEnable() 
    {
        rayKnife.rayKnifeSingalLaunch += InstantiateSliceFoodCheck;
        attachPositionApple.AttachPositionAppleSignalLaunch += currentOccupation;
    }

    private void OnDisable() 
    {
        rayKnife.rayKnifeSingalLaunch -= InstantiateSliceFoodCheck;
        attachPositionApple.AttachPositionAppleSignalLaunch -= currentOccupation;
    }

    
    private void InstantiateSliceFoodCheck()
    {                

        if(indexSliceFood <= sliceFood.Length)
        {
            Instantiate(sliceFood[indexSliceFood],positionToSpawn.position,positionToSpawn.rotation);
        }      

        indexSliceFood++;       
        

        if(indexSliceFood == sliceFood.Length)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.CompareTag("Hand") && positionOccuped == true)
        {
            transform.position = AttachPositionApple.position;
            transform.rotation = AttachPositionApple.rotation;
        }    
    }

    private void currentOccupation()
    {
        positionOccuped = true;
    }
    
    // if collide avec collide attach position 
    // attach position singal launch bool occuped  true
    // if occuped true ne fait rien. 


}
