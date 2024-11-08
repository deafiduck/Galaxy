using UnityEngine;
using UnityEngine.UI;
public class HeadMachine : MonoBehaviour
{
    //ESKİ KOD 

    int randomInt; //hangi dişin çekileceğini rastgele atıyor
    int randomYon;//dişi hangi yönden çekeceğimize bakıyor
    int numTooth = 32; //diş sayısı

    public Text text;
    public RawImage rawImageScreen; //masanın üstündeki bilgiyarın ekranı
    Ray ray; //diş için
    float maxDistance = 5;
    public LayerMask layersToHit;//film için

    public Texture2D st;
    public string photoname; //röntgenin hangi dişi çektiğini gösteriyor
    static public Texture2D selectedTexture; //fotoğrafı seçiyor

    ButtonController buttonController;
    [SerializeField] private LayerMask _layerToHit; //diş için layer

    Vector3 m_hitNormal;
    Vector3 m_tempPoint;
    RaycastHit hit;//dişin rayi
    RaycastHit hitF;//filmin rayi 
    static public bool film_ = false, rontgen = false, machine = false;

    bool upTooth, downTooth;
    //dişlerin alt açıyla mı üst açıyla mı çekildiğini kontrol bool değişkeni

    void Start()
    {
        Randomize();
        buttonController = FindObjectOfType<ButtonController>();
    }

    void Update()
    {
        if (Task.task3 == true)
        {
            FilmAngle();
        }
        //dişin alt veya üst açısını kontrol ediyor
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

        if (Physics.Raycast(ray, out hit, maxDistance, _layerToHit))
        {
            m_hitNormal = hit.normal;
            m_tempPoint = hit.point;

            photoname = "f" + hit.collider.gameObject.GetComponent<ToothClass>().m_toothIndex;
            Debug.Log("şu an " + photoname + "dişinin filmini çekiyosun, çekmen gereken diş" + randomInt);

            selectedTexture = null;

            for (int i = 0; i < numTooth; i++)
            {
                /*if (hit.collider.gameObject.GetComponent<ToothClass>().images[i].name == photoname)
                {
                    selectedTexture = hit.collider.gameObject.GetComponent<ToothClass>().images[i];//atanan fotoğraf seçiliyo
                    break;
                }*/
            }
            st = selectedTexture;
            if (selectedTexture != null)
            {
               // hit.collider.gameObject.GetComponent<ToothClass>().rawImage1.texture = selectedTexture;
                
                if (ButtonController.ButtonPressed == true) //butona dokundum mu kontrolü 
                {
                    if (Task.task4 == true)
                    {//task4 tamamlanmış mı diye kontrol et
                        Debug.Log("Task5 atandi, röntgen çek");
                        if (photoname == "f" + randomInt.ToString())
                        {
                            Task.task5 = true;
                            Task.Task6();
                        }
                        else
                        {
                            Debug.Log("Yanlış diş çekildi");
                            Clothes.resetClothes();

                        }
                    }
                    
                }
                else
                {
                    Debug.Log("Butona basılmadı");
                }
                
            }
            else
            {
                Debug.LogError("Görüntü bulunamadı: " + photoname);
            }
        }
        else//ray layerstohit ile bi yere çarpmazsa
        {
            m_hitNormal = Vector3.zero;
        }

        if (!m_hitNormal.Equals(Vector3.zero))
        {
            float angle = Vector3.Angle(transform.forward, m_tempPoint);

            // Sadece Y ekseni üzerindeki dönüş açısını hesaplıyo --- sağa ve sola dönünce açı değişiyor
            float yRotationAngle = Quaternion.FromToRotation(Vector3.forward, m_tempPoint - transform.position).eulerAngles.y;

            float xRotationAngle = Quaternion.FromToRotation(Vector3.forward, m_tempPoint - transform.position).eulerAngles.x;

            float zRotationAngle = Quaternion.FromToRotation(Vector3.forward, m_tempPoint - transform.position).eulerAngles.z;

            if (yRotationAngle > 180)
            {
                yRotationAngle -= 360;
            }

            if (xRotationAngle > 180)
            {
                xRotationAngle -= 360;
            }

            if (zRotationAngle > 180)
            {
                zRotationAngle -= 360;
            }
            if (55 > zRotationAngle && zRotationAngle > 0 && 55 > xRotationAngle && xRotationAngle > 0)
            {
                Debug.Log("makine asagi aciyla disi cekiyo");
                downTooth = true;
                upTooth = false;

            }
            else if (zRotationAngle < 0 && zRotationAngle > -55 && xRotationAngle < 0 && xRotationAngle > -55)
            {
                Debug.Log("makine yukarı aciyla disi cekiyo");
                upTooth = true;
                downTooth = false;
            }

        }
        if (film.checkFilm == true) //masanın üstündeki ekrana film görünütüsünü yolluyor
        {
            PrintScreen();
        }
    }

    void FilmAngle()
    {

        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);

        if (Physics.Raycast(transform.position, transform.forward, out hitF, maxDistance, layersToHit) && randomYon == 1 && downTooth == true)
        {
            if ("f" + randomInt == photoname)
            {
                
                Debug.Log("doğru diş alt açıyla çekildi ve film yerinde ");
                Task.task4 = true;
                //Debug.Log("film burda");
                film_ = true;
                rontgen = true;
            }
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hitF, maxDistance, layersToHit) && randomYon == 2 && upTooth == true)
        {
            if ("f" + randomInt == photoname)
            {
                
                Debug.Log("doğru diş üst açıyla çekildi ve film yerinde ");
                Task.task4 = true;
                //Debug.Log("film burda");
                film_ = true;
                rontgen = true;
            }
        }
        else if (randomYon == 1 && downTooth == true || randomYon == 2 && upTooth == true)
        {
            if ("f"+randomInt==photoname)
            {
                Task.task4 = false;
                Debug.Log("Diş doğru ama film yerinde değil");
            }
           
        }
    }
    public void PrintScreen()
    {
        rawImageScreen.texture = st;
        machine = true;
    }


    int Randomize()
    {
        randomYon = UnityEngine.Random.Range(1, 3); // 1 gelirse alt 2 gelirse üstten çek
        randomInt = UnityEngine.Random.Range(1, 2); // hangi diş için röntgen çekilecek gösterir. (1-32 arası)
        
        if (randomYon == 1)
        {
            //Debug.Log(randomInt + ". dişin röntgenini alttan çekiniz.");
            text.text = (randomInt + ". dişin röntgenini alttan çekiniz.");
            downTooth = false;
        }
        else if (randomYon == 2)
        {
            //Debug.Log(randomInt + ". dişin röntgenini üstten çekiniz.");
            text.text = (randomInt + ". dişin röntgenini alttan çekiniz.");
            upTooth = false;
        }

        return randomInt;
    }
}