using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //Task 1: kýyafeti giy
    //Task 2: eldiveni giy 
    //Task 3: dis filmini al ve film seridinin icine koy
    //Taks 4: filmi hastanin agzina yerlestir 
    //Task 5: Rastgele dislerin fotografini cek
    //Ek Task: Makine hangi diþin röntgenini çekti veriyi al
    //Task 6: filmi hastanýn aðzýndan al
    //Task 7: filmin dis seridini cikar
    //Task 8: eldiveni çöpe at
    //Task 9: filmi makineye yerlestir.
    public bool[] tasks = new bool[9];

    public bool isWestWeared = false; //task1
    public bool isGloveWeared = false; //task2
    public bool isFilmTaken = false; //task3
    public bool isPlacedSuccess = false; //taks4
    public bool isRayAndFilmMatching = false; //task5
    public bool isButtonPressed = false;//task5
    public bool isFilmTakenFromPatient = false;//task6
    public bool isStripTaken = false; //task7
    public bool isStripDisposed = false; //task8
    public bool isFilmInserted = false; //task9
    





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();
        Task8();
        Task9();

    }

    #region TaskSirasi
    public void Task1()
    {
        //Kiyafeti giydirme taski
        if(isWestWeared)
        {
            Debug.Log("Kiyafet Hastaya Giydirildi");
            tasks[0] = true;
        }
    }
    
    public void Task2()
    {
        //Eldivenler giyildi mi ?
        if(isGloveWeared && tasks[0] == true)
        {
            Debug.Log("Eldivenler Giyildi");
            tasks[1] = true;
         
        }
    }

    public void Task3()
    {
        //Filmleri yerinden al
        if (isFilmTaken  && tasks[1] == true)
        {
            Debug.Log("Film Alindi");
            tasks[2] = true;

        }
    }

    public void Task4()
    {
        //Filmi hastanin agzina yerlestir.
        if (isPlacedSuccess && tasks[2] == true)
        {
            //Dogru cekimde dogru fotograf gosterilecek.
            Debug.Log("Film hastanin agzina dogru yerlestirildi.");
            tasks[3] = true;

        }
        else if (!isPlacedSuccess && tasks[2] == true)
        {
            Debug.Log("Film hastanin agzina yanlis yerlestirildi.");
            //tasks[3] = true;
            // Hatali cekim sirasinda hatali gorselleri gostermek icin kod yazilacak

        }
    }

    public void Task5()
    {
        //Dis rontgenini cek
        if (isRayAndFilmMatching && tasks[3] && isButtonPressed == true)
        {
            Debug.Log("Rontgen isini dogru konumlandirildi.");
            tasks[4] = true;

        }
        else if (!isRayAndFilmMatching && tasks[3] && isButtonPressed == true)
        {
            //tasks[4] = true;
            //Hatali cekim icin kod eklenecek

        }
    }

    public void Task6()
    {
        //filmi hastanin agzindan al
        if(isFilmTakenFromPatient && tasks[4])
        {
            Debug.Log("Film Hastanin agzindan alindi");
            tasks[5] = true;
        }
    }

    public void Task7()
    {
        //Filmin seridini cikar
        if(isStripTaken && tasks[5])
        {
            Debug.Log("Serit cikartildi");
            tasks[6] = true;
        }
    }

    public void Task8()
    {
        //seridi cope at
        if(isStripDisposed && tasks[6])
        {
            Debug.Log("Serit cope atildi");
            tasks[7] = true;
        }
    }

    public void Task9()
    {
        if(isFilmInserted && tasks[7])
        {
            Debug.Log("Film cihaza yerlestirildi");
            tasks[8] = true;
        }
    }

    private void CheckTaskCompleted()
    {
        if(tasks[8] == true)
        {
            Debug.Log("Senaryo tamamlandi.");
        }
    }
    #endregion
    private void WrongOrderAttempt()
    {
        //Kullanici hatali sirayla yaparsa asamaya gore uyar.
    }

    

}
