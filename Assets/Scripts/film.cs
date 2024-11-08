using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class film : MonoBehaviour
{
    public GameObject film1; //doktorun elindeki diş filmi
    static public bool checkFilm = false; //filmin makineye yerleştirilip yerleştirilmediğini kontrol ediyor

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "machine") //filmi makineye yerleştirince doktorun elindeki filmin görünürlüğü kapanıyor
        {
            film1.SetActive(false);
            checkFilm = true; //film makineye yerleştirildi
            Debug.Log(checkFilm);
        }

    }

}