using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndTrhow : MonoBehaviour {



    Collider2D mycollider;
    [HideInInspector]
    public bool AbleToInteract = true;
    private Transform MySon;
    private Vector3 startposition;
    private Vector3[] GetLastPos = new Vector3[3];
    private Animator MiAnimacion;
    [SerializeField] AudioSource pedito;
    public static int  index;
    [SerializeField] ZonaManager managerDeZona;
   
    private void Start()
    {
        mycollider = GetComponent<Collider2D>();
        MySon = GetComponentInChildren<Transform>();
        startposition = transform.position;
        MiAnimacion = GetComponent<Animator>();
       

    }
    IEnumerator Throw(Vector3 FirstPosition,Vector3 dir)
    {
        float Distance = 0;
        while (Distance<20)
        {
            Distance=Vector3.Distance(FirstPosition, transform.position);
            transform.Translate(dir.normalized * Time.deltaTime*20);
            yield return null;
        }
        index++;
        Destroy(gameObject);
        if (index == 5)
        {
            managerDeZona.RelevoAPartidaManager();
            print("FIINISH");
        }


    }
    IEnumerator Dragging()
    {
        if (!MiAnimacion.GetBool("Cogido"))
        {
            pedito.Play();
        }
        MiAnimacion.SetBool("Cogido", true);
        while (Input.GetMouseButton(0))
        {
            Vector3 ThePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ThePosition = new Vector3(ThePosition.x, ThePosition.y, transform.position.z);
            transform.position = ThePosition;
            GetLastPos[0] = GetLastPos[1];
            GetLastPos[1] = GetLastPos[2];
            GetLastPos[2] = transform.position;
            yield return null;
        }
        StartCoroutine(Throw(transform.position,(transform.position-GetLastPos[0])));
    }
    private void OnMouseDown()
    {
        if (AbleToInteract)
        {
            
            StartCoroutine(Dragging());
        }
    }

}

