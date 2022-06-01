using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayKnife : MonoBehaviour
{
    public XRGrabInteractable XRGrabInteractable;
    public GameObject HandAccesScript;
    public XRRayInteractor XRRayInteractor;
    private Ray ray = new Ray(Vector3.zero, Vector3.right);
    private RaycastHit hit;
    private int layerMaskApple = 1 << 10;
    private bool currentActiveRay = false;

    private void Start()
    {
        currentActiveRay = true;
    }

    private void Update()
    {
        //Debug.DrawRay(transform.position+transform.forward*0.03f, transform.right+transform.forward*-0.02f, Color.green);
        RayKnifeContact();
        //DesactivateRay();
        ActivateRay();
    }

    private void OnEnable()
    {
        XRGrabInteractable.selectEntered.AddListener(CheckDesactivateBool);
        XRGrabInteractable.selectExited.AddListener(CheckActivateBool);
    }

    private void OnDisable()
    {
        XRGrabInteractable.selectEntered.RemoveListener(CheckDesactivateBool);
        XRGrabInteractable.selectExited.RemoveListener(CheckActivateBool);
    }

    private void DesactivateRay()
    {
        if (currentActiveRay == true)
        {
            HandAccesScript.GetComponent<XRRayInteractor>().enabled = true;
        }
        
    }

    private IEnumerator DelayDesactivateRay()
    {
        yield return new WaitForSeconds(1);
        DesactivateRay();
    }

    private void ActivateRay()
    {
        if (currentActiveRay == false)
        {
            HandAccesScript.GetComponent<XRRayInteractor>().enabled = false;
        }
        else
        {
            StartCoroutine(DelayDesactivateRay());
        }
        
    }

    private void CheckActivateBool(SelectExitEventArgs args)
    {
        //Debug.Log("ray activate");
        currentActiveRay = true;
    }

    private void CheckDesactivateBool(SelectEnterEventArgs args)
    {
        Debug.Log("ray desactivate");
        currentActiveRay = false; 
    }
    
    
    
    private void RayKnifeContact()
    {
        Ray ray = new Ray(transform.position+transform.forward*0.03f, transform.right+transform.forward*-0.02f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.5f,layerMaskApple))
        {
            Debug.Log("je coupe une pomme");
        }
    }
}
