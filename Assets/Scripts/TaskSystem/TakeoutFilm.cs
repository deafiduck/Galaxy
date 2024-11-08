using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeoutFilm : MonoBehaviour
{
    private GameObject taskmanager;

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }


    private void OnTriggerEnter(Collider other)
    {
        //rastgele di�lerin r�ngenini �ekme g�revi
        if (other.tag == "isStripTaken")
        {
            taskmanager.GetComponent<TaskManager>().isStripTaken = true;
        }
    }
}
