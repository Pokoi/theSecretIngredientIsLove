using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffectsManager : MonoBehaviour {

    [SerializeField] AudioClip golpe1;
    [SerializeField]  AudioClip golpe2;
    [SerializeField]  AudioClip golpe3;

    AudioSource source;

	// Use this for initialization
	void Start () {

        source = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {

       

		
	}

    public void SetAudioClip()
    {
        int numeroGolpe = Random.Range(1, 3);
        switch (numeroGolpe)
        {
            case 1:
                source.clip = golpe1;
                source.Play();
                break;
            case 2:
                source.clip = golpe2;
                source.Play();
                break;
            case 3:
                source.clip = golpe3;
                source.Play();
                break;
        }
    }



}
