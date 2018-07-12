using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraController : MonoBehaviour {

#region Inicialización de variables

    
    Transform rectanguloTransform;
    [SerializeField] float rectanguloSpeed = 200;
    Transform trianguloTransform;
    [SerializeField] float trianguloSpeed = 50;
    Transform limiteSuperior;
    Transform limiteInferior;
    [SerializeField] ZonaManager managerdeZona;

    [SerializeField] GameObject canvas;

    bool moving = true;
    bool rToUp = true;
    bool tToUp = true;
    bool isGrowing = false;
   

    [SerializeField] Animator rodilloAnimator;
    [SerializeField] GameObject prefab1pto;
    [SerializeField] GameObject prefab2pto;
    [SerializeField] Transform spawn;
    [SerializeField] GameObject aQuitar;
    [SerializeField] GameObject aPoner;
    [SerializeField] Animator animatorDelViejo;


    int puntos=0;
    [SerializeField] soundEffectsManager fxManager;

    #endregion 

    // Use this for initialization
    void Start () {

        rectanguloTransform = transform.GetChild(1).transform;
        trianguloTransform = transform.GetChild(2).transform;
        limiteSuperior = transform.GetChild(3).transform;
        limiteInferior = transform.GetChild(4).transform;
        canvas.SetActive(false);
        Invoke("SolucionGuarraDeEstoyHastaLosOvarios", 1.01f);

    }
	
	// Update is called once per frame
	void Update () {

        if (puntos < 7)
        {

            #region Movimiento del rectángulo

            if (rectanguloTransform.position.y < limiteSuperior.position.y && rToUp && moving)
                establecerPosicion(rectanguloTransform, limiteSuperior, rectanguloSpeed);

            if (rectanguloTransform.position.y > limiteInferior.position.y && !rToUp && moving)
                establecerPosicion(rectanguloTransform, limiteInferior, rectanguloSpeed);

            if (rectanguloTransform.position.y == limiteSuperior.position.y) rToUp = false;
            if (rectanguloTransform.position.y == limiteInferior.position.y) rToUp = true;



            #endregion

            #region Movmiento del triángulo
            if (trianguloTransform.position.y < limiteSuperior.position.y && tToUp && moving)
                establecerPosicion(trianguloTransform, limiteSuperior, trianguloSpeed);

            if (trianguloTransform.position.y > limiteInferior.position.y && !tToUp && moving)
                establecerPosicion(trianguloTransform, limiteInferior, trianguloSpeed);

            if (trianguloTransform.position.y == limiteSuperior.position.y) tToUp = false;
            if (trianguloTransform.position.y == limiteInferior.position.y) tToUp = true;

            #endregion

            #region Al pulsar el botón
            if (Input.GetMouseButtonDown(0))
            {
                if (moving)
                {
                    moving = false;
                    if (compareMatch())
                    {

                        rodilloAnimator.speed = 1f;
                        rodilloAnimator.SetTrigger("Attack");
                        fxManager.SetAudioClip();
                        Invoke("ActivarAnimacion", 0.2f);

                        GameObject instancia = Instantiate(prefab2pto, spawn.position, Quaternion.identity);
                        Destroy(instancia, 1.5f);
                        puntos += 2;
                        Invoke("setMovingTrue", 0.1f);
                    }

                    if (!compareMatch())
                    {

                        rodilloAnimator.SetTrigger("Attack");
                        fxManager.SetAudioClip();
                        rodilloAnimator.speed = 1f;
                        Invoke("ActivarAnimacion", 0.2f);
                        GameObject instancia = Instantiate(prefab1pto, spawn.position, Quaternion.identity);
                        Destroy(instancia, 1.5f);
                        puntos++;
                        Invoke("setMovingTrue", 0.1f);
                    }
                }
                
            }

            
            #endregion

        }
        if (puntos >= 7) {
            canvas.SetActive(true);
            managerdeZona.InvocarPasoSiguiente(2f); }
    }
    
    /// <summary>
    /// Función que comprueba si el triangulo se encuentra dentro del rectángulo al pulsar el ratón
    /// </summary>
    /// <returns></returns>
    private bool compareMatch()
    {
        float rectangleLimitSup = rectanguloTransform.position.y + (rectanguloTransform.GetComponent<Collider2D>().bounds.extents.y);
        float rectangleLimitInf = rectanguloTransform.position.y - (rectanguloTransform.GetComponent<Collider2D>().bounds.extents.y);     

        if (trianguloTransform.position.y < rectangleLimitSup && trianguloTransform.position.y > rectangleLimitInf) return true;
        else return false;
    }

    /// <summary>
    /// Función que mueve al objeto hacia el punto deseado 
    /// </summary>
    /// <param name="transformToMove"> transform del objeto a mover </param>
    /// <param name="targetTransformPosition"> transform de la posición destino </param>
    /// <param name="movementSpeed"> velocidad del movimiento </param>
    private void establecerPosicion( Transform transformToMove, Transform targetTransformPosition, float movementSpeed)
    {
        transformToMove.position = Vector3.MoveTowards(transformToMove.position, targetTransformPosition.position, movementSpeed * Time.deltaTime);
    }

    private void setMovingTrue() { moving = true; }
    
    private void SolucionGuarraDeEstoyHastaLosOvarios()
    {
        aQuitar.SetActive(false);
        aPoner.SetActive(true);

    }
    private void ActivarAnimacion()
    {
        animatorDelViejo.SetTrigger("golpeado");
    }
   
    
}
