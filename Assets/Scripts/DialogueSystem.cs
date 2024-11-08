using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    #region kendime notlar

    /*canvasý free space boyutuna gore yaptigim icin tahminen build sirasinda canvas gozukmeyecek.
     * O yuzden build alma sirasindaki ekran cozunurlugunu ogrenip ona gore canvasýn boyutunu ayarlamak gerek
     * ekran 1080p ise canvas 1920W 1080H olarak atanmasi lazim.
    */

    //Bu koda harcadigim saat : 5
    //yazmasi 1.5 saat
    //hata duzelmesi 3.5 saat

    #endregion

    #region Text mesajlari ve seslendirme degiskenleri
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] wrongChoiceLines;
    public float textSpeed = 1f;

    public AudioSource[] scenarioVoiceLines;
    public AudioSource[] wrongChoiceVoiceLines;
     

    #endregion

    #region senaryo Indexleri

    //senaryo indeksleri otomatik olarak 0 atanmýþtýr. Unity inspector uzerinden dizilerin eleman sayisi olusturulmadan
    //calistirilirsa hata verecektir.
    //!!INSPECTOR UZERINDEN DIZILERI TANIMLA
    //!INDEXLERE BURADAN MUDAHALE ETME. INSPECTOR UZERINDEN MUDAHALE ET.
    [SerializeField] private int index = 0;
    [SerializeField] private int wrongLineIndex = 0; //yanlis sirada yapildiginda uyarmak icin kullanilacak
    [SerializeField] private int wrongLineSoundIndex = 0; //senaryoda yanlis sirada islem yapildiginda kullanilacak audiosourcelar
    [SerializeField] private int soundIndex = 0; //senaryo akisinda kullanýlan audio sourcelari
    


    [SerializeField] private GameObject canvas;
    #endregion

    #region doktor fotografi ve rawimage

    public Texture2D[] photos;
    [SerializeField] private RawImage rawImg;
    [SerializeField] private int photoIndex = 0;
    #endregion


    void Start()
    {

        textComponent.text = string.Empty;
        StartDialogue();

    }

    void Update()
    {
        LineDebug();
        ChangeImageDebug();

    }
    #region Diyalog sistemi
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        if(index < lines.Length)
        {
            textComponent.text = string.Empty;
            if (soundIndex < scenarioVoiceLines.Length)
            {

                if (scenarioVoiceLines[soundIndex] != null)
                {
                    scenarioVoiceLines[soundIndex].Play();
                }
            }
            //harfleri sirayla dizmek icin foreach kullanildi
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            
            
        }
        else
        {
            Debug.Log("Line index arrayden buyuk.");
            yield return new WaitForSeconds(0);
        }
        
    }

    IEnumerator TypeWrongLine()
    {
        if(wrongLineIndex < wrongChoiceLines.Length)
        {
            textComponent.text = string.Empty; //String temizlenir.

            if(wrongLineSoundIndex < wrongChoiceVoiceLines.Length)
            {
                
                if (wrongChoiceVoiceLines[wrongLineSoundIndex] != null)
                {
                    wrongChoiceVoiceLines[wrongLineSoundIndex].Play();
                }
            }
            

            foreach (char c in wrongChoiceLines[wrongLineIndex].ToCharArray())
            {
                textComponent.text += c;

                yield return new WaitForSeconds(textSpeed);
            }
            
        }
        else
        {
            Debug.Log("WrongLine index arrayden buyuk.");
            yield return new WaitForSeconds(0);
        }

    }

    private void NextLine()
    {
        //Yeni bir siraya
        textComponent.text = string.Empty; //String temizlenir.

        if(index < lines.Length -1 )
        {
            //eger index gelecek cumlelerden kucuk ise indeksi arttir
            index++;
            soundIndex++;
            //eger yanlis harekette calisacak cumlenin indexi yanlis cumleler indeksinden kucukse indexi arttir
            if(wrongLineIndex <= wrongChoiceLines.Length -1)
            {
                wrongLineIndex++;
                wrongLineSoundIndex++;
            }
            StartCoroutine(TypeLine());
            
        }
        else
        {
            //index kucuk degil ise canvasý kapat
            //yazýlacak tüm diyaloglar bittiðinde canvasý kapatýr.
            canvas.SetActive(false);
        }
    }

    private void LineDebug()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            //StopAllCoroutines();
            //NextLine();
            NextDialogue();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //StopAllCoroutines();
            //StartCoroutine(TypeWrongLine());
            StartWrongDialogue();
        }
    }

    public void NextDialogue()
    {
        //Disaridan bir scriptle senaryo diyaloguna erisilecek ise bu metodu cagir.
        StopAllCoroutines();
        NextLine();
    }

    public void StartWrongDialogue()
    {
        //Disaridan bir scriptle hatali secim diyaloguna  erisilecek ise bu metodu cagir.

        StopAllCoroutines();
        StartCoroutine(TypeWrongLine());
    }



    #endregion

    #region rawimage kismi

    public void SetImageTexture(int photoIndex) 
    {
        //Bu metot TaskManager üzerinden komut gönderilerek de çalýþtýrýlabilir, bu script içerisinden de çalýþtýrýlabilir.
        //Fotograf degerinin el ile verilmesi gerekiyor.
        if(photoIndex >= photos.Length)
        {
            Debug.Log("Verilen fotograf indeksi dizinin indeksinden büyük");
            return;
        }
        rawImg.texture = photos[photoIndex];
    }

    public void ChangeImageDebug()
    {
        //test amacli yapildi. Sonradan kaldirilacak.
        if(Input.GetKeyDown(KeyCode.O) && photoIndex <= photos.Length - 1 )
        {
            rawImg.texture = photos[photoIndex];
            photoIndex++;
        }
        if(Input.GetKeyDown(KeyCode.O) && photoIndex > photos.Length - 1)
        {
            photoIndex = 0;
        }
    }



    #endregion

}
