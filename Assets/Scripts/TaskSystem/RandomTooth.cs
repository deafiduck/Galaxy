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
            Debug.Log(randomInt + ". di�in r�ntgenini alttan �ekiniz.");
        }
        else if (randomYon == 2)
        {
            Debug.Log(randomInt + ". di�in r�ntgenini �stten �ekiniz.");
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
                    Debug.Log("Do�ru di�in r�ntgeni �ekiliyor ve y�n� do�ru");
                    taskmanager.GetComponent<TaskManager>().isRayAndFilmMatching = true;
                }
                else
                {
                    Debug.Log("Do�ru di�in r�ntgeni �ekiliyor ancak makinenin a��s� yanl��");
                }
               
            }
            else
            {
                Debug.Log("Ray, di�e ve filme �arp�yor. Ancak yanl�� di�in r�ntgeni �ekiliyor.");
            }
            
        }
        else
        {
            Debug.Log("Ray, di�e ve filme �arpm�yor.");
        }
    }

    private void OnTriggerEnter(Collider other) //odan�n d���na buton koyaca��z. Butona bas�l�nca r�ntgen �ekilecek.
    {
        if (other.tag == "button")
        {
            taskmanager.GetComponent<TaskManager>().isButtonPressed = true;
            //Toothcheck'�n burada �a��r�lmas� laz�m. Test etmek amac�yla fixedupdate i�inde �a��rd�m.
        }
    }
}
