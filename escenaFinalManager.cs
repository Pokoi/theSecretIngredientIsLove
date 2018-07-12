using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escenaFinalManager : MonoBehaviour {

	int organosColocados= 0;
	[SerializeField] private Text creditsTitle;
    [SerializeField] Transform corazon;
    [SerializeField] Transform higado;
    [SerializeField] Transform pancreas;
    [SerializeField] Transform timo;
    [SerializeField] Transform rinion;
    [SerializeField] AudioSource cancionFinal;
    AudioSource cancionInicial;


    void Start(){
		creditsTitle.gameObject.SetActive (false);
        cancionInicial = transform.parent.GetComponent<AudioSource>();
	}

    private void Update()
    {
        Debug.Log(organosColocados);
        if (organosColocados == 5)
        {
            creditsTitle.gameObject.SetActive(true);
            corazon.GetComponent<Collider>().enabled = true;
            higado.GetComponent<Collider>().enabled = true;
            pancreas.GetComponent<Collider>().enabled = true;
            timo.GetComponent<Collider>().enabled = true;
            rinion.GetComponent<Collider>().enabled = true;

        }


    }

    public void setOrganoColocado(){
		organosColocados++;
        if (organosColocados == 1)
        {
            cancionFinal.Play();

        }
        cancionFinal.volume += 0.2f;
        cancionInicial.volume -= 0.2f;
        if (organosColocados == 5)
        {
            creditsTitle.gameObject.SetActive(true);
            corazon.GetComponent<Collider>().enabled = true;
            higado.GetComponent<Collider>().enabled = true;
            pancreas.GetComponent<Collider>().enabled = true;
            timo.GetComponent<Collider>().enabled = true;
            rinion.GetComponent<Collider>().enabled = true;

        }

	}

	public int getOrganosColocados(){
		return organosColocados;
	}
}
