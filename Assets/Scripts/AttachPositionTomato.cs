using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPositionTomato : MonoBehaviour
{    
    /// <summary>
	/// Script assign to attach position tomato prefab, that do fixe tomato prefab 
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
        if (other.CompareTag("tomato") && exitPosition == false)
        {               
            AttachTomato();
        }   
    }

    
    /// <summary>
	/// method for fixe tomato prefab and is calling if attach tomato prefab collision with that prefab 
	/// </summary>
    private void AttachTomato()
    {       
        GameObject food = GameObject.FindGameObjectWithTag("tomato");
        food.transform.rotation = transform.rotation;
        food.transform.position = transform.position;
    }
    
    
    
    private void CheckStayBool(HoverExitEventArgs args)
    {  
        if(args.interactable.CompareTag("tomato"))
        {
            exitPosition = false;
        }
    }

    private void CheckExitBool(HoverEnterEventArgs args)
    {
        if(args.interactable.CompareTag("tomato"))
        {
            exitPosition = false;
        }       
    }
}
