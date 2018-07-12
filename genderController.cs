using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class genderController : MonoBehaviour {


    Text text;

	// Use this for initialization
	void Start () {

        text = transform.GetChild (3).GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void textVegan()
    {
        text.text = "Thank you, maybe you will be able to play another day";
        Invoke("quitApp", 1.5f);
       
    }

    public void textGender()
    {
        text.text = "Thank you, but this really doesn't matter in this game";
    }

    private void quitApp()
    {
        Application.Quit();
    }

}
