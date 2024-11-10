using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource Tan�t�mSes;
    public bool m_Play = true;

    void Start()
    {
        // E�er AudioSource bile�eni yoksa hata vermemesi i�in kontrol eklendi
        Tan�t�mSes = GetComponent<AudioSource>();

        if (Tan�t�mSes != null)
        {
            StartCoroutine(Bekleme()); // Coroutine ba�lat�ld�
        }
        else
        {
            Debug.LogWarning("AudioSource bile�eni bu objede bulunamad�.");
        }
    }

    IEnumerator Bekleme()
    {
        yield return new WaitForSeconds(5);

        if (m_Play && Tan�t�mSes != null)
        {
            Tan�t�mSes.Play();
        }
    }
}
