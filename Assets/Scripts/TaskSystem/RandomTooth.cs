using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTooth : MonoBehaviour
{
    private GameObject taskmanager;
    private GameObject angleCalculator;
    private GameObject toothmanager;

    int randomInt;
    int randomYon;

    void Start()
    {
        taskmanager = GameObject.FindGameObjectWithTag("TaskManager");
        angleCalculator = GameObject.FindGameObjectWithTag("AngleCalculator");
        toothmanager= GameObject.FindGameObjectWithTag("ToothManager");
        Randomize();
    }

    private void FixedUpdate()
    {
        ToothCheck();
    }

    int Randomize()
    {
        randomYon = UnityEngine.Random.Range(1, 3);
        randomInt = UnityEngine.Random.Range(0, 32);

        if (randomYon == 1)
        {
            Debug.Log(randomInt + ". diþin röntgenini alttan çekiniz.");
        }
        else if (randomYon == 2)
        {
            Debug.Log(randomInt + ". diþin röntgenini üstten çekiniz.");
        }

        return randomInt;
    }

    void ToothCheck()
    {
        Debug.Log($"checktooth: {angleCalculator.GetComponent<AngleCalculator>().checktooth}, checkfilm: {angleCalculator.GetComponent<AngleCalculator>().checkfilm}");
        if (angleCalculator.GetComponent<AngleCalculator>().checktooth && angleCalculator.GetComponent<AngleCalculator>().checkfilm)
        {
            if (toothmanager.GetComponent<MatchToothPhoto>().m_toothIndex== randomInt )
            {
                if(angleCalculator.GetComponent<AngleCalculator>().isAngleUp == randomYon)
                {
                    Debug.Log("Doðru diþin röntgeni çekiliyor ve yönü doðru");
                    taskmanager.GetComponent<TaskManager>().isRayAndFilmMatching = true;
                }
                else
                {
                    Debug.Log("Doðru diþin röntgeni çekiliyor ancak makinenin açýsý yanlýþ");
                }
               
            }
            else
            {
                Debug.Log("Ray, diþe ve filme çarpýyor. Ancak yanlýþ diþin röntgeni çekiliyor.");
            }
            
        }
        else
        {
            Debug.Log("Ray, diþe ve filme çarpmýyor.");
        }
    }

    private void OnTriggerEnter(Collider other) //odanýn dýþýna buton koyacaðýz. Butona basýlýnca röntgen çekilecek.
    {
        if (other.tag == "button")
        {
            taskmanager.GetComponent<TaskManager>().isButtonPressed = true;
            //Toothcheck'Ýn burada çaðýrýlmasý lazým. Test etmek amacýyla fixedupdate içinde çaðýrdým.
        }
    }
}
