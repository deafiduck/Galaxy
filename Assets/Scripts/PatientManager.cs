using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    [SerializeField]    
    private GameObject patient;
    [SerializeField]
    private Transform patientTransform;
    
    
    

    private void Start()
    {
        
        SpawnPatient();
        
        //zort
        
       
    }

    

    void SpawnPatient()
    {
        if (patient == null)
        {
            Debug.Log("patient boþ");
        }
        else
        {
            Debug.Log("DOLU");
            Instantiate(patient, patientTransform.transform.position, new Quaternion(0,-90,0,0));
        }
    }

}
