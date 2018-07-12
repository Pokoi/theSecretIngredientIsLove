using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class organosNivelFinal : MonoBehaviour {

	 #region Inicialización de variables
    Transform miTransform;  
    
    Animator miAnimator;

    enum Organo{corazon, higado, rinion, pancreas, timo};
    [SerializeField] Organo miOrgano;
    
	[SerializeField]Transform transformPosicionEnSarten;
    bool organoSoltado;
	bool organoEnSarten;

	[SerializeField] private escenaFinalManager managerFinal;

	private Text creditsText;




    #endregion


	// Use this for initialization
	void Start () {
		miTransform = transform;
		miAnimator = GetComponent<Animator>();
		organoSoltado = true;
		organoEnSarten = false;
		creditsText = managerFinal.gameObject.transform.GetChild (0).GetComponent<Text> ();
		creditsText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
            newPos.z = transform.position.z;
            transform.position = newPos;
        }

		if (Input.GetMouseButtonUp (0)) {
			organoSoltado = true;
			miAnimator.SetBool ("Cogido", false);
			}

		if (Input.GetMouseButtonDown (0)) {
			organoSoltado = false;
			miAnimator.SetBool ("Cogido", true);
			}

		if(managerFinal.getOrganosColocados()==5){

			if (miOrgano == Organo.corazon)
				creditsText.text = "Miguel García Cebrián" + "\n" + "2D Artist" + "\n"+ "@tremulo_dev (twitter)" + "\n"+ "@miquigaud (instagram)";
			if (miOrgano == Organo.higado)
				creditsText.text = "Jose A. Jiménez" + "\n"+"3D Artist & animations"+"\n" + "@JoseJJ333";
			if (miOrgano == Organo.rinion)
				creditsText.text = "Miguel Sánchez Santos-Olmo" + "\n" + "Code" + "\n" + "@Sr_Ciruelo";
			if (miOrgano == Organo.timo)
				creditsText.text = "Jesús 'Pokoi' Villar" + "\n" + "Code" + "\n"+ "pokoidev.com";
			if (miOrgano == Organo.pancreas)
				creditsText.text = "Ana Castro Puebla" + "\n" + "Music & UI Artist" + "\n" + "@pollosauriox"; 
			creditsText.gameObject.SetActive (true);
			
		}

    }

	private void OnMouseExit(){
		creditsText.gameObject.SetActive (false);
	
	}
   
   

    private void OnTriggerStay(Collider other)
    {
		if (other.tag == "Circle" && organoSoltado) {
            if (managerFinal.getOrganosColocados() < 5)
            {
                transform.position = transformPosicionEnSarten.position;
                miAnimator.SetTrigger("Baile");
                managerFinal.setOrganoColocado();
                transform.GetComponent<Collider>().enabled = false;
            }

            
		}
    }


					
}
