using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCabbage : MonoBehaviour
{
    /// <summary>
	/// that small script for change scale to Y axe the cabbage Prefab when that to position over sandwich preparation
	/// </summary>

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
