using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioFlecha : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cortar.CanStartDetecting = true;
        Animator MiCuchillo= FileteManager.Cuchillo.transform.GetChild(0).GetComponent<Animator>();
        MiCuchillo.SetInteger("Estado", 1);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Animator MiCuchillo = FileteManager.Cuchillo.transform.GetChild(0).GetComponent<Animator>();
        MiCuchillo.SetInteger("Estado", 0);
    }
}
