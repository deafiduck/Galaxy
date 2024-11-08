using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFilmPatient : MonoBehaviour
{
    private GameObject taskmanager;

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }


    private void OnTriggerEnter(Collider other)
    {
        //rastgele diþlerin röngenini çekme görevi
        if (other.tag == "take_film_patient")
        {
            taskmanager.GetComponent<TaskManager>().isFilmTakenFromPatient = true;
        }
    }
}
