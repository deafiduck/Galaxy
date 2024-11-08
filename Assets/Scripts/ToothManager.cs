using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothManager : MonoBehaviour
{
    public GameObject[] Teeth=new GameObject[32];
    public void Start()
    {
        for (int j = 0; j < 32; j++)
        {
            Teeth[j].GetComponent<ToothClass>().m_toothIndex = j;

        }

    }
    public ToothClass SendTooth(int id) {
        
        return Teeth[id].GetComponent<ToothClass>();
    }

}
