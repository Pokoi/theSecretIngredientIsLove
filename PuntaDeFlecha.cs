using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntaDeFlecha : MonoBehaviour
{
    private Transform Flecha;
    private Cortar FlechaScript;
    private void Start()
    {
        Flecha = transform.parent;       
        FlechaScript = Flecha.GetComponent<Cortar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FlechaScript.GoodDirectionX && (Mathf.Sign(ColliderRaton.MouseColliderPos.y - FlechaScript.LastPositionOfMouse.y) == Mathf.Sign(FlechaScript.RotacionY)))
        {
            FlechaScript.stopmyroutine();
            FlechaScript.SetScore(FlechaScript);
        }
    }

}
