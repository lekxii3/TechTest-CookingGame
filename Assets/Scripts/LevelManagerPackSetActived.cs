using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPackSetActived : MonoBehaviour
{
   [SerializeField]private GameObject[] food;   
   [SerializeField]private GameObject[] foodSetDesactivate;
    public GameObject sandwichPrefab;
    public Transform sandwichPrefabToSpawn;
    private int indexArrayFood=0;
    private int NumberCheckPosition=0;

    private void FixedUpdate() 
    {
       InstantiateSanwdich();
    }
    private void OnEnable() 
    {
        CheckSnapBread.CheckSnapHeritageSignalLaunch += Activate;    
        ChechSnapCheese.CheckSnapHeritageSignalLaunch += Activate;
        CheckSnapTomato.CheckSnapHeritageSignalLaunch += Activate;
        CheckSnapCabbage.CheckSnapHeritageSignalLaunch += Activate;
    }

    private void OnDisable() 
    {
        CheckSnapBread.CheckSnapHeritageSignalLaunch -= Activate;
        ChechSnapCheese.CheckSnapHeritageSignalLaunch -= Activate;    
        CheckSnapTomato.CheckSnapHeritageSignalLaunch -= Activate;
        CheckSnapCabbage.CheckSnapHeritageSignalLaunch -= Activate;
    }

    private void Activate()
    {
        if(indexArrayFood<food.Length)
        {
            food[indexArrayFood].SetActive(true);     
        }                 
        indexArrayFood++;
        NumberCheckPosition++;       


        Debug.Log(NumberCheckPosition);
    }

    private void InstantiateSanwdich()
    {
        if(NumberCheckPosition==6)
        {
            for (int i = 0; i < food.Length; i++)
            {
                foodSetDesactivate[i].SetActive(false);
            }

            for (int i = 0; i < food.Length; i++)
            {
                food[i].SetActive(false);
            }
                         
            GameObject newSandwich = Instantiate(sandwichPrefab, sandwichPrefabToSpawn.position, sandwichPrefabToSpawn.rotation );
            
            NumberCheckPosition=0;
        }
    }
        
}
