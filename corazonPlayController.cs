using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazonPlayController : MonoBehaviour
{

    [SerializeField] GameObject canvasGender;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            canvasGender.SetActive(true);
            transform.gameObject.SetActive(false);
        }
    }
}
