using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaManager : MonoBehaviour {

    PartidaManager partidaManager;
    [SerializeField]GameObject nextPrefab;

	// Use this for initialization
	void Start () {

        partidaManager = transform.parent.GetChild(0).GetComponent<PartidaManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InvocarPasoSiguiente(float time = 2)
    {
        Invoke("RelevoAPartidaManager", time);
    }

    public void RelevoAPartidaManager()
    {
        partidaManager.crearContenido(nextPrefab);
        partidaManager.destruirContenidoActual(this.gameObject);
    }
}
