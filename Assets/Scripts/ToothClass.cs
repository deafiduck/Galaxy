using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToothClass : MonoBehaviour
{

    [SerializeField]
    public string m_toothName;
    [SerializeField]
    public int m_toothIndex;


    public RawImage rawImage1;
    //public Texture2D[] images; //diþ fotoðraflarýandan oluþan dizi

   
   

    [SerializeField]
    
    public void Tooth()
    {
        Debug.Log(m_toothIndex);
    }


    [ContextMenu("Init")]
    public void InitializeTooth(int number, string name)
    {
        m_toothIndex = number;
        m_toothName = name;
    }


    public int GetToothNumber()
    {
        Debug.Log("Interacting with" + m_toothName);
        return m_toothIndex;
    }


}
