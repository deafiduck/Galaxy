using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveBox : MonoBehaviour
{
    //task2
    private GameObject taskmanager;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private Material gloveMaterial;
    [SerializeField] private GameObject gloveProp;

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hands") //eldiven kutusuna hands tag'i verilecek
        {
            Debug.Log("El iceriye girdi");
            taskmanager.GetComponent<TaskManager>().isGloveWeared = true;
            leftHand.GetComponent<SkinnedMeshRenderer>().material = gloveMaterial;
            rightHand.GetComponent<SkinnedMeshRenderer>().material = gloveMaterial;
            gloveProp.SetActive(false);


        }
    }
}
