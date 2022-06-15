using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class AttachPositionBread : MonoBehaviour
{
    /// <summary>
	/// Script assign to attach position bread prefab, that do fixe bread prefab 
	/// </summary>
    public XRRayInteractor XRRayInteractor;    
    private bool exitPosition = false;
    

    private void OnEnable()
    {
        XRRayInteractor.hoverEntered.AddListener(CheckExitBool);
        XRRayInteractor.hoverExited.AddListener(CheckStayBool);
    }

    private void OnDisable()
    {
        XRRayInteractor.hoverEntered.RemoveListener(CheckExitBool);
        XRRayInteractor.hoverExited.RemoveListener(CheckStayBool);
    }  


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("bread") && exitPosition == false)
        {               
            AttachBread();
        } 
    }

    
    /// <summary>
	/// method for fixe bread prefab and is calling if attach bread prefab collision with that prefab 
	/// </summary>
    private void AttachBread()
    {       
        GameObject food = GameObject.FindGameObjectWithTag("bread");        
        food.transform.rotation = transform.rotation;
        food.transform.position = transform.position;
    }
    
    
    
    private void CheckStayBool(HoverExitEventArgs args)
    {  
        if(args.interactable.CompareTag("bread"))
        {
            exitPosition = false;
        }
    }

    private void CheckExitBool(HoverEnterEventArgs args)
    {
        if(args.interactable.CompareTag("bread"))
        {
            exitPosition = false;
        }       
    }
}
