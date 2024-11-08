using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFilm : MonoBehaviour
{

    private GameObject taskmanager;

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "take_film")
        {
            taskmanager.GetComponent<TaskManager>().isFilmTaken = true;
        }
    }
}
