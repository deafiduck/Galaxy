using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedFilm : MonoBehaviour
{
    private GameObject taskmanager;

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }


    private void OnTriggerEnter(Collider other)
    {
        //doktorun elindeki film hastan�n a�z�na yerle�tirildi mi kontrol� yap�lacak (�imdilik b�yle)
        if (other.tag == "filmplaced")
        {
            taskmanager.GetComponent<TaskManager>().isPlacedSuccess = true;
        }
    }
}
