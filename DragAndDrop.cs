using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{

    Collider2D mycollider;
    [SerializeField]
    private Collider2D MyInteractable;
    [HideInInspector]
    public bool AbleToInteract=true;
    private Transform MySon;
    private Vector3 startposition;
    private void Start()
    {
        mycollider = GetComponent<Collider2D>();
        MySon = GetComponentInChildren<Transform>();
        startposition = transform.position;

    }
    private void Interact()
    {
        ContactFilter2D Filter = new ContactFilter2D();
        //Filter.useDepth = true;
        Collider2D[] MyResults = new Collider2D[40];
        Physics2D.OverlapCollider(mycollider, Filter, MyResults);
        foreach(Collider2D i in MyResults)
        {
            if (i == MyInteractable)
            {
                transform.position= i.transform.GetChild(0).transform.position;
                AbleToInteract = false;
            }
        }
        if (AbleToInteract)
        {
            transform.position= startposition;
        }
    }
    IEnumerator Dragging()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 ThePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ThePosition = new Vector3(ThePosition.x, ThePosition.y, transform.position.z);
            transform.position = ThePosition;
            yield return null;
        }
        Interact();
    }
    private void OnMouseDown()
    {
        if(AbleToInteract)StartCoroutine(Dragging());
    }

}
