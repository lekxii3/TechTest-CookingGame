using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPackSetActived : MonoBehaviour
{
    /// <summary>
	/// Script for levelManager, this manage check assembly food and instantiate sandwich and victory message
	/// </summary>
    public delegate void LevelManagerPackSetActivedSignal();
    public static event LevelManagerPackSetActivedSignal LevelManagerPackSetActivedSignalLaunch;
   [SerializeField]private GameObject[] stocketFoodElementPosition;   
   [SerializeField] private GameObject[] cylinderColorChange;
   public Material materialGrey;
   public Material materialGreen;
   public GameObject victory;
   
    public GameObject sandwichPrefab;
    public Transform sandwichPrefabToSpawn;
    private int indexArrayFood=0;
    private int NumberCheckPosition=0;

    private void Start() 
    {
        foreach (GameObject cylinder in cylinderColorChange)
        {
            cylinder.GetComponent<MeshRenderer>().material = materialGrey;
        }    
    }

    private void FixedUpdate() 
    {
       InstantiateSanwdich();
    }
    private void OnEnable() 
    {
        CheckSnapBread.CheckSnapHeritageSignalLaunch += ActivateAndChangeColorCylinder;    
        ChechSnapCheese.CheckSnapHeritageSignalLaunch += ActivateAndChangeColorCylinder;
        CheckSnapTomato.CheckSnapHeritageSignalLaunch += ActivateAndChangeColorCylinder;
        CheckSnapCabbage.CheckSnapHeritageSignalLaunch += ActivateAndChangeColorCylinder;
        CheckSnaoBread2.CheckSnapHeritageSignalLaunch += ActivateAndChangeColorCylinder;
    }

    private void OnDisable() 
    {
        CheckSnapBread.CheckSnapHeritageSignalLaunch -= ActivateAndChangeColorCylinder;
        ChechSnapCheese.CheckSnapHeritageSignalLaunch -= ActivateAndChangeColorCylinder;    
        CheckSnapTomato.CheckSnapHeritageSignalLaunch -= ActivateAndChangeColorCylinder;
        CheckSnapCabbage.CheckSnapHeritageSignalLaunch -= ActivateAndChangeColorCylinder;
        CheckSnaoBread2.CheckSnapHeritageSignalLaunch -= ActivateAndChangeColorCylinder;
    }


    /// <summary>
	/// This methods calling for each event CheckSnapHeritageSignalLaunch for change color cylinder to green and setActive=true for enable each stocket for receive the next element food 
	/// </summary>
    private void ActivateAndChangeColorCylinder()
    {
        cylinderColorChange[indexArrayFood].GetComponent<MeshRenderer>().material = materialGreen;

        if(indexArrayFood<stocketFoodElementPosition.Length)
        {
            stocketFoodElementPosition[indexArrayFood].SetActive(true);     
        }                 
        indexArrayFood++;
        NumberCheckPosition++;  
        Debug.Log(NumberCheckPosition);
    }

    /// <summary>
	/// This methods calling when the value NumberCheckposition=5 for :
    /// -launch event LevelManagerPackSetActivedSignalLaunch for SliceMonobehavior script
    /// -SetActive=false each stocket
    /// -SetActive=true a Sprite victory
    /// -Instantiate prefab Sandwich
	/// </summary>
    private void InstantiateSanwdich()
    {
        if(NumberCheckPosition==5)
        {
            LevelManagerPackSetActivedSignalLaunch?.Invoke();

            for (int i = 0; i < stocketFoodElementPosition.Length; i++)
            {
                stocketFoodElementPosition[i].SetActive(false);
            }
            victory.SetActive(true);             
            GameObject newSandwich = Instantiate(sandwichPrefab, sandwichPrefabToSpawn.position, sandwichPrefabToSpawn.rotation );
            
            NumberCheckPosition=0;
        }
    }
        
}
