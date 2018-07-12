using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartidaManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void destruirContenidoActual(GameObject objetoADestruir)
    {
        Destroy(objetoADestruir);
    }

    public void crearContenido(GameObject prefab)
    {
        GameObject instancia = Instantiate(prefab);
        instancia.transform.SetParent (transform.parent);
    }
}
