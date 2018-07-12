using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraSarten : MonoBehaviour {

    Transform rectanguloTransform;
    [SerializeField] float rectanguloSpeed = 200;
    Transform limiteSuperior;
    Transform limiteInferior;

    bool moving = true;
    public static bool rToUp = true;
    bool tToUp = true;
    bool isGrowing = false;
    public static int NivelFuego=2;
    private float NumeroFuego=100;


    // Use this for initialization
    void Start()
    {

        rectanguloTransform = transform.GetChild(1).transform;
        limiteSuperior = transform.GetChild(2).transform;
        limiteInferior = transform.GetChild(3).transform;
    }
    public void SubirFuego()
    {
        switch (NivelFuego)
        {
            case 4:
                NivelFuego = 4;
                break;
            case 2:
                NivelFuego = 4;
                break;
            case -2:
                NivelFuego = 2;
                break;
            case -4:
                NivelFuego = -2;
                break;
        }
    }
    public void BajarFuego()
    {
        switch (NivelFuego)
        {
            case 4:
                NivelFuego = 2;
                break;
            case 2:
                NivelFuego = -2;
                break;
            case -2:
                NivelFuego = -4;
                break;
            case -4:
                NivelFuego = -4;
                break;
        }
    }
    void Update()
    {

        #region Movimiento del rectángulo

        if (rectanguloTransform.position.y < limiteSuperior.position.y && rToUp && moving)
            establecerPosicion(rectanguloTransform, limiteSuperior);

        if (rectanguloTransform.position.y > limiteInferior.position.y && !rToUp && moving)
        {
            establecerPosicion(rectanguloTransform, limiteInferior);
        }

        if (NivelFuego<0)
        {
            rToUp = false;
        }
        if (NivelFuego > 0)
        {
            rToUp = true;
        }
        float Diferencia;
        if (rToUp)
        {
            Diferencia = limiteSuperior.position.y - rectanguloTransform.position.y;
        }
        else
        {
            Diferencia = limiteInferior.position.y - rectanguloTransform.position.y;
        }

        if((Mathf.Abs(Diferencia)<5 && Mathf.Abs(Diferencia)> 3.5f))
        {
            NumeroFuego += 1;
            NumeroFuego = Mathf.Clamp(NumeroFuego, 0, 100);
        }
        else if((Mathf.Abs(Diferencia) < 3.5f && Mathf.Abs(Diferencia) > 1.7))
        {
            NumeroFuego -= 0.3f;
            NumeroFuego = Mathf.Clamp(NumeroFuego, 0, 100);
        }
        else
        {
            NumeroFuego -= 0.6f;
            NumeroFuego = Mathf.Clamp(NumeroFuego, 0, 100);
        }

        #endregion
        if (NumeroFuego == 0)
        {
            //Sad Knife
            print("HAS PERDIDO");
        }


    }


    private void establecerPosicion(Transform transformToMove, Transform targetTransformPosition)
    {
        transformToMove.position = Vector3.MoveTowards(transformToMove.position, targetTransformPosition.position, Mathf.Abs(NivelFuego) * Time.deltaTime);
    }
}
