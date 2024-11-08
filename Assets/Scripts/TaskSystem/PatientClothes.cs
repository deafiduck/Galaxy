using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientClothes : MonoBehaviour
{
    //task1
    private GameObject taskmanager;
    [SerializeField] private GameObject patientClothes;
    [SerializeField] private GameObject clothes; //yerden alinacak kiyafet

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "clothes")
        {
            taskmanager.GetComponent<TaskManager>().isWestWeared = true;
            Destroy(clothes);
            patientClothes.SetActive(true);

        }
    }
}
