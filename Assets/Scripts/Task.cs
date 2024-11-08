using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Task : MonoBehaviour
{
    //Task 1: k�yafeti giy
    //Task 2: eldiveni giy 
    //Task 3: dis filmini al
    //Taks 4: filmi hastanin agzina yerlestir 
    //Task 5: random bir di� ata, o di�i �ek
    //Task 6: eldiveni ��pe at
    //Task 7: filmi hastan�n a�z�ndan al

    
    public string selectedTexture; //se�ilen ana rontgen goruntusu
    public GameObject righthand;
    public GameObject lefthand;
    [SerializeField]
    static public bool task1 = false, task2 = false, task3 = false, task4 = false, task5 = false, task6 = false, task7 = false; //t�m g�revler ba�lang��ta yap�lmad��� i�in false durumunda

    public GameObject clothes, film, film1; //hastan�n giyece�i k�yafet ve dis filmi
    public bool check; //k�yafetin giyilmedi�ini g�steriyor
    bool isFilmTaken = false; //film alinmadigi icin false

    public bool control = false; //agzin icindeki herhangi bir film aktif ise true olur 

    public GameObject colorchangeObject; //ColorChange icin kullanilacak objeyi belirledim


    private void Start()
    {
        check = true;
        pthotus(selectedTexture);

    }

    public void pthotus(string photoname)
    {
        selectedTexture = photoname;
    }
    private void Update()
    {
        if (!task1)
        {
            Task1();

        }
        else if (task1 && !task2)
        {
            Task2();
        }
        else if (task1 && task2 && !task3)
        {
            Task3();
        }
        else if (task1 && task2 && task4 && !task5)
        {
            Task4();
        }

        else if (task1 && task2 && task3 && task4 && !task5)
        {
            Task5();
        }
        else if (task1 && task2 && task3 && task4 && task5 && !task6)
        {
            Task6();
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "clothes")
        {
            StartCoroutine(Clothees());
            clothes.SetActive(false);
            check = false; //k�yafet art�k giyildi
        }

        else if (other.gameObject.tag == "film")
        {
            StartCoroutine(Film());
            film.SetActive(false);
            isFilmTaken = true; //film alindigi icin true oldu
        }

    }

    IEnumerator Film()
    {
        Debug.Log("Film alindi");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Clothees()
    {
        Debug.Log("K�yafet giyildi");
        yield return new WaitForSeconds(1f);
    }


    void Task1() //K�yafeti giyme g�revi
    {
        if (task1 == false)
        {
            Debug.Log("task1 atand�, k�yafeti giy");
            if (check == false) //k�yafet giyilmi�se 
            {
                Debug.Log("Task1 i�ine girdi");
                task1 = true;
               
            }
            else
            {
                task1 = false;
                Debug.Log("Task1i tamamlamadiniz... ");
            }
        }
        else
        {
            task1 = true;
            Debug.Log("Task1 tamamland�");
        }

    }
    void Task2() //eldiveni giyme g�revi
    {
        Debug.Log("task2 atand�, eldiveni  giy");
        if (task2 == false && task1 == true)
        {
            //Yorum satirina alinan kod degistirildi. Materyal kiyaslamasi yapmak yerine boolean degeri kontrol ediliyor.

            //    if (righthand.gameObject.GetComponent<Renderer>().material.color == Color.red)
            //    {
            //        task2 = true;
            //        Debug.Log("eldiven giyildi");
            //    }

            //else
            //{
            //    task2 = false;
            //    Debug.Log("Task1i tamamlamadiniz... ");
            //}

            if (colorchangeObject.GetComponent<ColorChanged>().isChanged == true)
            {
                task2 = true;
                Debug.Log("eldiven giyildi");
            }

            else
            {
                task2 = false;
                Debug.Log("Task1i tamamlamadiniz... ");
            }
        }

        else
        {
            task2 = true;
            Debug.Log("Task2 tamamland�");
        }

    }

    void Task3() //dis filmini alma gorevi Task5 den Task3 e �evirildi
    {
        if (task3 == false)
        {
            Debug.Log("Task3 atandi, filmi al");
            if (isFilmTaken == false)
            {
                task3 = false;
                Debug.Log("Filmi almaniz gerekiyor!, Task3'i tamamlamadiniz");
                isFilmTaken = false; //film al�nmad�
            }
            else //film alindi
            {
                task3 = true;
                Debug.Log("Filmi aldiniz, rontgen cekebilirsiniz!, Task3 tamamlandi");
                film1.SetActive(true); //doktorun elindeki filmin g�r�n�rl��� aktif olsun
                isFilmTaken = true;
            }
        }
        else
        {
            task3 = true;
            film1.SetActive(true);
            isFilmTaken = true;
        }
    }

    void Task4()//Task6 dan task 4 e �evirildi
    {
        if (task3 == true)
        {
            //head machine scriptindeki FilmAngle fonksyionu 
        }
        else
        {
            Debug.Log("Task 3 yap�lmad�");
        }

    }
    void Task5()//di� r�ntgen �ekimi headmachine scriptinde yap�ld�
    {
        if (HeadMachine.rontgen&& ButtonController.buttonPressed)
        {
            task5 = true;
        }

    }

    public static void Task6()//task4den task6ya �evirildi
    {
        
        if (task6 == false)
        {
            Debug.Log("Task6 atandi, eldiveni ��pe at");
            if (task5 == true)
            {
                if (!ColorChanged.a)//k�rm�z� ise a=true ��pe at�lm��sa a = false
                {
                    task6 = true;
                    Debug.Log("basarili");
                }

            }
            else
            {
                Debug.Log("Task5i tamamlamadiniz... ");

            }
        }
        else
        {
            Debug.Log("Task6 tamamland�");

        }
    }

    void Task7()
    {
        //filmin g�r�nt�s� makineye yerle�tirilecek

        if (HeadMachine.machine == true)
        {
            task7 = true;
        }
    }

}