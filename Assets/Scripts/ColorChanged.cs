using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanged : MonoBehaviour
{
    public Material gloveMaterial;
    public Material mt; //elin kendi materyali
    public GameObject righthand;
    public GameObject lefthand;
    public bool isChanged = false; //burada a degiskenini anlamadim. O yuzden bunu tanimladim. Bu degiskeni Task scriptine gondermek icin kullandim
    //public Color mt;
    public static bool a = false;

    private void Start()
    {
        //mt = righthand.gameObject.GetComponent<Renderer>().material.color;
        mt = righthand.gameObject.GetComponent<SkinnedMeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(Task.task1 == true) //1. görev tamamlanmışsa eldiven giyilebilsin
        {
            if (collision.gameObject.tag == "cube")
            {
                //yorum satirina alinan kod degistirildi. Renderer componentine degil skinnedMeshRenderer'a bakiyor

                // 'cube' etiketine sahip bir nesneyle  arp  ma ger ekle ti inde yap lacak i lemler
                //righthand.gameObject.GetComponent<Renderer>().material.color = Color.red;
                //lefthand.gameObject.GetComponent<Renderer>().material.color = Color.red;
                //a = true;

                righthand.gameObject.GetComponent<SkinnedMeshRenderer>().material = gloveMaterial;
                lefthand.gameObject.GetComponent<SkinnedMeshRenderer>().material = gloveMaterial;
                a = true;
                isChanged = true;
                Debug.Log("Eldiven değişti.");
            }
            if (collision.gameObject.tag == "trash" && a == true) //eldiveni çöp kutusuna atma işlemi
            {
                //yorum satirina alinan kod degistirildi. Renderer componentine degil skinnedMeshRenderer'a bakiyor

                //righthand.gameObject.GetComponent<Renderer>().material.color = mt;
                //lefthand.gameObject.GetComponent<Renderer>().material.color = mt;
                //a = false;

                righthand.gameObject.GetComponent<SkinnedMeshRenderer>().material = mt;
                lefthand.gameObject.GetComponent<SkinnedMeshRenderer>().material= mt;
                a = false;
                isChanged = false;
            }
        }
       
    }


}