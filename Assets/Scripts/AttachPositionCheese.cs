using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPositionCheese : MonoBehaviour
{
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
        
        if (other.CompareTag("cheese") && exitPosition == false)
        {               
            AppleStayPosition();
        }               
        
    }

    

    private void AppleStayPosition()
    {       
        GameObject food = GameObject.FindGameObjectWithTag("cheese");
        //Vector3 position = apple.transform.position + transform.up;
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
