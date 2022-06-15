using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayKnife : MonoBehaviour
    
{
    /// <summary>
	/// Script manage behaviour and event during collision with other gameObject && box collider knife check OnTrigger
	/// </summary>


    public delegate void RayKnifeSingal();
    
    /// <summary>
	/// event variable launch if collision with prefab CompareTag("tomato")
	/// </summary>
    public static event RayKnifeSingal rayKnifeSingalTomatoLaunch;

    /// <summary>
	/// event variable launch if collision with prefab CompareTag("Bread")
	/// </summary>
    public static event RayKnifeSingal rayKnifeSingalBreadLaunch;

    /// <summary>
	/// event variable launch if collision with prefab CompareTag("Cheese")
	/// </summary>
    public static event RayKnifeSingal rayKnifeSingalCheeseLaunch;   
    public XRGrabInteractable XRGrabInteractable;    
    public GameObject HandAccesScript;    
    private bool currentActiveRay = false;
    

    private void Start()
    {
        currentActiveRay = true;
    }

    private void Update()
    {        
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


    
    /// <summary>
	/// if the controller hand grab the knife prefab, the ray GetComponent<LineRenderer>() is desactivate withe delay. 
	/// </summary>
    private IEnumerator DelayDesactivateRay()
    {
        yield return new WaitForSeconds(0.2f);
        DesactivateRay();
    }

      private void DesactivateRay()
    {
        if (currentActiveRay == false)
        {
            HandAccesScript.GetComponent<LineRenderer>().enabled = false;
            HandAccesScript.GetComponent<XRInteractorLineVisual>().enabled = false;
        }
        
    }

    /// <summary>
	/// if the controller hand no longer grab the knife prefab, the ray GetComponent<LineRenderer>() is Activate. 
	/// </summary>
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


    /// <summary>
	/// that currentActiveRay is bool for allow choice methode ActivateRay() or DesactivateRay()
	/// </summary>
    private void CheckActivateBool(SelectExitEventArgs args)
    {        
        currentActiveRay = true;
    }

    private void CheckDesactivateBool(SelectEnterEventArgs args)
    {        
        currentActiveRay = false; 
    }
    
    
 
    /// <summary>
	/// Event Launch if collision with prefab food 
	/// </summary>
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

        if(other.CompareTag("cheese"))
        {
            rayKnifeSingalCheeseLaunch?.Invoke();   
        }
       
    }











    //public XRRayInteractor XRRayInteractor;
    //private Ray ray = new Ray(Vector3.zero, Vector3.right);
    //private RaycastHit hit;

    //Debug.DrawRay(transform.position+transform.forward*0.03f, transform.right+transform.forward*-0.02f, Color.green);
    //RayKnifeContact();
    //DesactivateRay();




   
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
