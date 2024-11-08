using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] points; // Rotadaki noktalar
    public float speed = 2f; // Karakterin h�z�

    private int destPoint = 0; // Hedeflenen nokta indeksi
    private Animator animator; // Animator bile�eni

    void Start()
    {
        Debug.Log("�al���yo mu");
        animator = GetComponent<Animator>();
        GotoNextPoint();
    }

    void Update()
    {
        // Her karede karakteri bir sonraki noktaya do�ru hareket ettir
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // E�er noktalar tan�mlanmam��sa ��k�� yap
        if (points.Length == 0)
            return;

        // Karakteri hedef noktaya do�ru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, points[destPoint].position, speed * Time.deltaTime);

        // E�er karakter hedef noktaya ula�t�ysa, bir sonraki noktay� hedefle
        if (Vector3.Distance(transform.position, points[destPoint].position) < 0.3f)
        {
            // Y�r�me animasyonunu ba�lat
            animator.SetBool("isWalking", false);

            // Bir sonraki noktaya ge�
            destPoint = (destPoint + 1) % points.Length;

            // Coroutine ba�lat
            StartCoroutine(MoveToNextPoint());
        }
        else
        {
            // Y�r�me animasyonunu ba�lat
            animator.SetBool("isWalking", true);
        }
    }

    IEnumerator MoveToNextPoint()
    {
        // Bir sonraki noktaya ula��lana kadar bekle
        while (Vector3.Distance(transform.position, points[destPoint].position) > 0.3f)
        {
            yield return null;
        }

        // Yeni hedef noktaya hareket etmeyi ba�lat
        GotoNextPoint();
    }
}
