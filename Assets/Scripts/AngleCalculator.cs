using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCalculator : MonoBehaviour
{
    public Vector3 tooth_hitNormal, film_hitNormal;
    public Vector3 tooth_tempPoint, film_tempPoint;
    public RaycastHit toothHit, filmHit;
    public Ray toothRay, filmRay;
    float maxDistance = 50;
    public LayerMask layersToHit_tooth, layersToHit_film;

    public bool upTooth, downTooth;
    public bool checktooth, checkfilm;
    public int isAngleUp; //aþaðý açý ile çekiyorsak 1, yukarý açý ile çekiyorsak 2 olur 

    void Start()
    {
        // Baþlangýçta yapýlacak iþlemler
    }

    void FixedUpdate()
    {
        RaycastTooth();
        RaycastFilm();
        AngleTooth();
        AngleFilm();
    }

    public void RaycastTooth()
    {
        toothRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        if (Physics.Raycast(toothRay, out toothHit, maxDistance, layersToHit_tooth))
        {
            tooth_hitNormal = toothHit.normal;
            tooth_tempPoint = toothHit.point;
            checktooth = true;
        }
        else
        {
            checktooth = false;
        }
    }

    public void AngleTooth()
    {
        if (!tooth_hitNormal.Equals(Vector3.zero))
        {
            Vector3 directionToHitPoint = tooth_tempPoint - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToHitPoint);
            Vector3 eulerAngles = Quaternion.FromToRotation(Vector3.forward, directionToHitPoint).eulerAngles;
            float xRotationAngle = NormalizeAngle(eulerAngles.x);
            float zRotationAngle = NormalizeAngle(eulerAngles.z);

            if (0 < zRotationAngle && zRotationAngle < 55 && 0 < xRotationAngle && xRotationAngle < 55)
            {
                Debug.Log("Makine aþaðý açýyla diþi çekiyor");
                downTooth = true;
                upTooth = false;
                isAngleUp = 1;
            }
            else if (-55 < zRotationAngle && zRotationAngle < 0 && -55 < xRotationAngle && xRotationAngle < 0)
            {
                Debug.Log("Makine yukarý açýyla diþi çekiyor");
                upTooth = true;
                downTooth = false;
                isAngleUp = 2;
            }
        }
    }

    public void RaycastFilm()
    {
        filmRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.yellow);
        if (Physics.Raycast(filmRay, out filmHit, maxDistance - 20, layersToHit_film))
        {
            film_hitNormal = filmHit.normal;
            film_tempPoint = filmHit.point;
            checkfilm = true;
        }
        else
        {
            checkfilm = false;
        }
    }

    public void AngleFilm()
    {
        if (!film_hitNormal.Equals(Vector3.zero))
        {
            Vector3 directionToFilmPoint = film_tempPoint - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToFilmPoint);
            Vector3 eulerAngles = Quaternion.FromToRotation(Vector3.forward, directionToFilmPoint).eulerAngles;
            float xRotationAngle = NormalizeAngle(eulerAngles.x);
            float zRotationAngle = NormalizeAngle(eulerAngles.z);

            if (-7 < zRotationAngle && zRotationAngle < 7 && -7 < xRotationAngle && xRotationAngle < 7)
            {
                Debug.Log("ýþýn filme dik vurdu");
            }
        }
    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }
}
