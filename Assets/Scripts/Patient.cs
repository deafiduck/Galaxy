using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] points; // Rotadaki noktalar
    public float speed = 2f; // Karakterin hýzý

    private int destPoint = 0; // Hedeflenen nokta indeksi
    private Animator animator; // Animator bileþeni

    void Start()
    {
        Debug.Log("çalýþýyo mu");
        animator = GetComponent<Animator>();
        GotoNextPoint();
    }

    void Update()
    {
        // Her karede karakteri bir sonraki noktaya doðru hareket ettir
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Eðer noktalar tanýmlanmamýþsa çýkýþ yap
        if (points.Length == 0)
            return;

        // Karakteri hedef noktaya doðru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, points[destPoint].position, speed * Time.deltaTime);

        // Eðer karakter hedef noktaya ulaþtýysa, bir sonraki noktayý hedefle
        if (Vector3.Distance(transform.position, points[destPoint].position) < 0.3f)
        {
            // Yürüme animasyonunu baþlat
            animator.SetBool("isWalking", false);

            // Bir sonraki noktaya geç
            destPoint = (destPoint + 1) % points.Length;

            // Coroutine baþlat
            StartCoroutine(MoveToNextPoint());
        }
        else
        {
            // Yürüme animasyonunu baþlat
            animator.SetBool("isWalking", true);
        }
    }

    IEnumerator MoveToNextPoint()
    {
        // Bir sonraki noktaya ulaþýlana kadar bekle
        while (Vector3.Distance(transform.position, points[destPoint].position) > 0.3f)
        {
            yield return null;
        }

        // Yeni hedef noktaya hareket etmeyi baþlat
        GotoNextPoint();
    }
}
