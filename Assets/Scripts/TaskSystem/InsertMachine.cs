using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InsertMachine : MonoBehaviour
{
    //task 9
    private GameObject taskmanager;  
    private GameObject toothmanager;
    
    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
        toothmanager= GameObject.FindGameObjectWithTag("ToothManager");
    }


    private void OnTriggerEnter(Collider other) //film makineye yerleþtirildiðinde bilgisayara filmin görüntüsü gelecek (kodu filme attým)
    {
        
        if (other.tag == "machine")
        {
            taskmanager.GetComponent<TaskManager>().isFilmInserted = true;
            toothmanager.GetComponent<MatchToothPhoto>().PrintScreen();
            Debug.Log("Film makineye yerleþtirildi.");
            this.gameObject.SetActive(false);
        }
    }
}
