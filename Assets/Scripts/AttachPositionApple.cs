using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPositionApple : MonoBehaviour
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
        if (other.CompareTag("apple") && exitPosition == false)
        {
            AppleStayPosition();
        }
    }
    
    private void AppleStayPosition()
    {
        GameObject apple = GameObject.FindGameObjectWithTag("apple");
        //Vector3 position = apple.transform.position + transform.up;
        apple.transform.rotation = transform.rotation;
        apple.transform.position = transform.position;
    }
    
    
    
    private void CheckStayBool(HoverExitEventArgs args)
    {
        exitPosition = false;
    }

    private void CheckExitBool(HoverEnterEventArgs args)
    {
        exitPosition = true; 
        
    }
}
