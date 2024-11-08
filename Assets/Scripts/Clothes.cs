using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    public static GameObject clothes;
    public static bool check = true;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "clothes")
        {
            StartCoroutine(Clothees());
            clothes.SetActive(false);
            check = false;

        }

    }
    public static void resetClothes()
    {
        clothes.SetActive(true);
        check = true;
    }
    IEnumerator Clothees()
    {
        Debug.Log("Kýyafet giyildi");
        yield return new WaitForSeconds(1f);
    }


}