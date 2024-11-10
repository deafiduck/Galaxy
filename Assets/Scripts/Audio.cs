using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource TanýtýmSes;
    public bool m_Play = true;

    void Start()
    {
        // Eðer AudioSource bileþeni yoksa hata vermemesi için kontrol eklendi
        TanýtýmSes = GetComponent<AudioSource>();

        if (TanýtýmSes != null)
        {
            StartCoroutine(Bekleme()); // Coroutine baþlatýldý
        }
        else
        {
            Debug.LogWarning("AudioSource bileþeni bu objede bulunamadý.");
        }
    }

    IEnumerator Bekleme()
    {
        yield return new WaitForSeconds(5);

        if (m_Play && TanýtýmSes != null)
        {
            TanýtýmSes.Play();
        }
    }
}
