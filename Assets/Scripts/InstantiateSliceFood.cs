using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSliceFood : MonoBehaviour
{   
    /// <summary>
	/// Script for instantiate slice prefab when the script Inheritance from that script event signal launch {TomatoBehaviour,CheeseBehaviour,BreadBehaviour} 
	/// </summary>
        
    public GameObject[] sliceFood;
    public int indexSliceFood=0;
    public Transform positionToSpawn;


    
    public void InstantiateSliceFoodCheck()
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














    //public AttachPositionApple attachPositionApple;
    //public DetachPosition detachPosition;
    // public Transform AttachPositionApple;
    //public bool currentOneByOne = false;
    //private bool positionOccuped = false;

    /*private void OnEnable() 
    {
        //RayKnife.rayKnifeSingalLaunch += InstantiateSliceFoodCheck;
        //attachPositionApple.AttachPositionAppleSignalLaunchOccuped += currentOccupationOccuped;
        //detachPosition.DetachPositionSignalLaunch += currentOccupeationFree;
    }

    private void OnDisable() 
    {
        //RayKnife.rayKnifeSingalLaunch -= InstantiateSliceFoodCheck;
        //attachPositionApple.AttachPositionAppleSignalLaunchOccuped -= currentOccupationOccuped;
        //detachPosition.DetachPositionSignalLaunch -= currentOccupeationFree;
    }*/


   

    /*private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("4");
        if(other.collider.CompareTag("Hand") && positionOccuped == true)
        {
            Debug.Log("5");
            transform.position = AttachPositionApple.position;
            transform.rotation = AttachPositionApple.rotation;
        }    
    }*/



    /*private void test()
    {
        Debug.Log("4");
        if(positionOccuped == true)
        {
            Debug.Log("5");
            transform.position = AttachPositionApple.position;
            transform.rotation = AttachPositionApple.rotation;
        }    
    }*/
   


    /*private void currentOccupationOccuped()
    {
        Debug.Log("3");
        positionOccuped = true;
    }

    private void currentOccupeationFree()
    {
        Debug.Log("8");
        positionOccuped = false;
    }*/
    
    // if collide avec collide attach position 
    // attach position singal launch bool occuped  true
    // if occuped true ne fait rien. 


}
