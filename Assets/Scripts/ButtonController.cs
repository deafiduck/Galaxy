using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour //röntgeni çekmek için butona basmak gerekli 
{
    public static bool buttonPressed = false; // butona basılmış mı diye kontrol ediyor

    public static bool ButtonPressed
    {
        get { return buttonPressed; }
        set { buttonPressed = value; }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "button")
        {
            Debug.Log("butona basıldı");
            ButtonPressed = true; // Değişiklik burada
        }
    }
}
