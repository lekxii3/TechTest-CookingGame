using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayKnife : MonoBehaviour
{
    public delegate void RayKnifeSingal();
    public static event RayKnifeSingal rayKnifeSingalTomatoLaunch;
    public static event RayKnifeSingal rayKnifeSingalBreadLaunch;
    public InstantiateSliceFood instantiateSliceFood;

    public XRGrabInteractable XRGrabInteractable;
    public XRInteractorLineVisual XRInteractorLineVisual;
    public GameObject HandAccesScript;
    //public XRRayInteractor XRRayInteractor;
    //private Ray ray = new Ray(Vector3.zero, Vector3.right);
    //private RaycastHit hit;
    private int layerMaskApple = 1 << 10;
    private bool currentActiveRay = false;
    public bool contactFood =false;

    private void Start()
    {
        currentActiveRay = true;
    }

    private void Update()
    {
        //Debug.DrawRay(transform.position+transform.forward*0.03f, transform.right+transform.forward*-0.02f, Color.green);
        //RayKnifeContact();
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
        if (currentActiveRay == false)
        {
            HandAccesScript.GetComponent<LineRenderer>().enabled = false;
            HandAccesScript.GetComponent<XRInteractorLineVisual>().enabled = false;
        }
        
    }

    private IEnumerator DelayDesactivateRay()
    {
        yield return new WaitForSeconds(0.2f);
        DesactivateRay();
    }

    private void ActivateRay()
    {
        if (currentActiveRay == true)
        {
            HandAccesScript.GetComponent<LineRenderer>().enabled = true;
            HandAccesScript.GetComponent<XRInteractorLineVisual>().enabled = true;
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
        //Debug.Log("ray desactivate");
        currentActiveRay = false; 
    }
    
    
 

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("tomato"))
        {
            rayKnifeSingalTomatoLaunch?.Invoke();   
        }

        if(other.CompareTag("bread"))
        {
            rayKnifeSingalBreadLaunch?.Invoke();   
        }
    }







   
    /*private void RayKnifeContact()
    {
        Ray ray = new Ray(transform.position+transform.forward*0.03f, transform.right+transform.forward*-0.02f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.5f,layerMaskApple))
        {
            contactFood=true;   
            instantiateSliceFood.currentOneByOne=true;         
            rayKnifeSingalLaunch?.Invoke();                     
        }
        else
        {
            instantiateSliceFood.currentOneByOne=false;   
            contactFood=false;            
        }
    }*/




}
