using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleArrowMovement : MonoBehaviour {

    #region Inicialización de variables
    Transform miTransform;  
    [SerializeField] private Text pointsText;
    float points;
    private bool removedorIsMoving;
    #endregion


    // Use this for initialization
    void Start () {
        miTransform = transform;
    }

    private void Update()
    {
        pointsText.text = points.ToString();        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
        if (Input.GetMouseButtonUp(0)) removedorIsMoving = false;
        if (Input.GetMouseButtonDown(0)) removedorIsMoving = true;
    }

    private void OnMouseExit()
    {
        removedorIsMoving = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Circle" && removedorIsMoving) points++;
    }
}
