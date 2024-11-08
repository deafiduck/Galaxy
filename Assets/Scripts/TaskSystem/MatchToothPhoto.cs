using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MatchToothPhoto : MonoBehaviour
{
    public RawImage rawImageScreen;
    public Texture2D temp;
    public string photoname;
    public Texture2D selectedTexture;
    public int numTooth = 28;
    public Texture2D[] images = new Texture2D[28];
    public GameObject ray;
    public int m_toothIndex;
    [SerializeField]
    public ToothClass[] Teeth=new ToothClass[32];
    private RaycastHit hit;

    private void Start()
    {
        ray = GameObject.FindGameObjectWithTag("AngleCalculator");

        if (ray != null)
        {
            hit = ray.GetComponent<AngleCalculator>().toothHit;
        }
        else
        {
            Debug.LogError("Ray atan nesne bulunamadı.");
        }

        for (int j = 0; j < numTooth; j++)
        {
            photoname = "f" + j;
            selectedTexture = Resources.Load<Texture2D>(photoname);

            if (selectedTexture != null)
            {
                images[j] = selectedTexture;
            }
            else
            {
                Debug.LogWarning("Fotoğraf bulunamadı: " + photoname);
            }
        }
    }

    private void FixedUpdate()
    {
        if (ray != null)
        {
            hit = ray.GetComponent<AngleCalculator>().toothHit;
            Match();
        }
    }

    public void Match()
    {
        if (hit.collider != null && hit.collider.GetComponent<Collider>() != null && hit.collider.GetComponent<Collider>().gameObject.tag == "Tooth")
        {
            m_toothIndex = hit.collider.GetComponent<ToothClass>().m_toothIndex;
            photoname = "f" + m_toothIndex;
            selectedTexture = null;

            for (int i = 0; i < numTooth; i++)
            {
                if (images[i].name == photoname)
                {
                    selectedTexture = images[i];
                    break;
                }
            }

            temp = selectedTexture;
            Debug.Log(photoname);
           // PrintScreen();
        }
        else
        {
            Debug.Log("herhangi bir dişe çarpmadı");
        }
    }

    public void PrintScreen()
    {
        rawImageScreen.texture = temp;
    }
}
