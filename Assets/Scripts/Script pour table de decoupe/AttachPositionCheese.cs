using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPositionCheese : MonoBehaviour
{
    /// <summary>
	/// Script assign to attach position cheese prefab, that do fixe cheese prefab 
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
        if (other.CompareTag("cheese") && exitPosition==false)
        {               
            AttachCheese();
            exitPosition = true;
        }
    }

    
    /// <summary>
	/// method for fixe cheese prefab and is calling if attach cheese prefab collision with that prefab 
	/// </summary>
    private void AttachCheese()
    {       
        GameObject food = GameObject.FindGameObjectWithTag("cheese");
        food.transform.rotation = transform.rotation;
        food.transform.position = transform.position;
    }
    
    
    
    private void CheckStayBool(HoverExitEventArgs args)
    {  
        if(args.interactable.CompareTag("cheese"))
        {
            exitPosition = false;
        }
    }

    private void CheckExitBool(HoverEnterEventArgs args)
    {
        if(args.interactable.CompareTag("cheese"))
        {
            exitPosition = false;
        }       
    }
}
