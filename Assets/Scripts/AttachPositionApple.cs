using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPositionApple : MonoBehaviour
{
    public delegate void AttachPositionAppleSignal();
    public static event AttachPositionAppleSignal AttachPositionAppleSignalLaunch;
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
        
        if (other.CompareTag("food") && exitPosition == false)
        {
            AttachPositionAppleSignalLaunch?.Invoke();
        }
        
    }
    
    private void AppleStayPosition()
    {
        positionOccuped = true;

        GameObject food = GameObject.FindGameObjectWithTag("food");
        //Vector3 position = apple.transform.position + transform.up;
        food.transform.rotation = transform.rotation;
        food.transform.position = transform.position;
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
