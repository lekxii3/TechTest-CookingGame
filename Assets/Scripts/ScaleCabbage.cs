using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCabbage : MonoBehaviour
{
    public Transform positionAttach;

    private void FixedUpdate() 
    {
        Vector3 scaleOrigin = new Vector3(0.32936f,0.32936f,0.32936f);
        Vector3 scaleModified = new Vector3(0.32936f,0.1f,0.32936f);
        if(transform.position == positionAttach.position)
        {
            transform.localScale = scaleModified;
        }    
        else
        {
            transform.localScale = scaleOrigin;
        }
    }    
}
