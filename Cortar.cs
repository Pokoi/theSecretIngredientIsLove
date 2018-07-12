using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cortar : MonoBehaviour {

    private Transform MiFlecha;
    public Vector2 LastPositionOfMouse;
    public static float Score=0;
    private int MaxTime;
    [HideInInspector]
    public float RotacionX;
    [HideInInspector]
    public float RotacionY;
    [HideInInspector]
    public float time=0;
    [HideInInspector]
    public float CorrectTime=0;
    public static bool finished;
    public static float penalty;
    public static bool CanStartDetecting;
    private float MyTime;
    public bool GoodDirectionX;
    public bool GoodDirectionY;
    [SerializeField]
    private FileteManager MyManager;
    [HideInInspector]
    public Vector2[] LastPositions= new Vector2[3];
	void Start ()
    {
        MiFlecha = GetComponent<Transform>();
        GetDirection();
        StopAllCoroutines();
        StartCoroutine(StartCounting());

    }
    public void SetScore(Cortar FlechaScript)
    {
        if (FlechaScript.time != 0)
        {
            Cortar.Score = FlechaScript.CorrectTime /  (Mathf.Pow(2, FlechaScript.time)) + Cortar.penalty;
        }
        Cortar.Score= Mathf.Clamp(Cortar.Score, 0, 50);
        FlechaScript.time = 0;
        FlechaScript.CorrectTime = 0;
        Cortar.finished = false;
        Cortar.CanStartDetecting = false;
        Cortar.Score = 0;
        Cortar.penalty = 0;
        FileteManager.Puntuations.Add(Score);
        MyManager.SiguienteFlecha();
      
    }
	void GetDirection()
    {
        RotacionX = Mathf.Cos(MiFlecha.eulerAngles.z*Mathf.PI/180);
        RotacionY = Mathf.Sin((MiFlecha.eulerAngles.z*Mathf.PI)/180);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LastPositionOfMouse = ColliderRaton.MouseColliderPos;
        float MiZ = (MiFlecha.eulerAngles.z) - 90;
        FileteManager.Cuchillo.transform.rotation= Quaternion.Euler(new Vector3(FileteManager.Cuchillo.transform.eulerAngles.x, FileteManager.Cuchillo.transform.eulerAngles.y, MiZ=(MiZ>180)?MiZ-180:MiZ));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanStartDetecting)
        {
            GoodDirectionX= (Mathf.Sign(ColliderRaton.MouseColliderPos.x - LastPositionOfMouse.x) == Mathf.Sign(RotacionX));
            GoodDirectionY = (Mathf.Sign(ColliderRaton.MouseColliderPos.y - LastPositionOfMouse.y) == Mathf.Sign(RotacionY));
            if (GoodDirectionX && GoodDirectionY && LastPositionOfMouse != ColliderRaton.MouseColliderPos)
            {
                CorrectTime += 20;
            }
            LastPositions[0] = LastPositions[1];
            LastPositions[1] = LastPositions[2];
            LastPositions[2] = ColliderRaton.MouseColliderPos;
            LastPositionOfMouse = LastPositions[0];
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        penalty -= 0.01f;
    }
    IEnumerator StartCounting()
    {
        while (!finished)
        {
            time += 0.15f;
            yield return null;
        }

    }
    public void stopmyroutine()
    {
        Animator MiCuchillo = FileteManager.Cuchillo.transform.GetChild(0).GetComponent<Animator>();
        MiCuchillo.SetInteger("Estado", 0);
        Destroy(gameObject);
    }
    void FixedUpdate ()
    {
        MyTime += Time.deltaTime;
        
        if (Input.GetMouseButton(0))
        {
            Score = 0;
            time = 0;
            CorrectTime = 0;
            finished = false;
        }

    }
}
