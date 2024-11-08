using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    private GameObject taskmanager;
    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }


    private void OnTriggerEnter(Collider other)
    {
        //rastgele diþlerin röngenini çekme görevi
        if (other.tag == "garbage")
        {
            taskmanager.GetComponent<TaskManager>().isStripDisposed = true;
        }
    }
}
