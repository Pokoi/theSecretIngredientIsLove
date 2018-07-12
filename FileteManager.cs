using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileteManager : MonoBehaviour
{
    public static List<float> Puntuations = new List<float>();
    public GameObject[] Flechitas;
    private byte Index=1;
    public Animator Animadura;
    public GameObject Cuchilleto;
    public static GameObject Cuchillo;
    [SerializeField] private ZonaManager zonaManager;
    [SerializeField] private GameObject canvasBocadillo;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private bool OtherThingsHappening;
    [SerializeField] private GameObject Organos;
    public void Awake()
    {
        Cuchillo = Cuchilleto;

    }

    private void Start()
    {
        canvasBocadillo.SetActive(false);
    }
    private void Update()
    {
        Cuchillo.transform.rotation = Quaternion.Euler(new Vector3(Cuchillo.transform.eulerAngles.x, - Camera.main.ScreenToWorldPoint(Input.mousePosition).x*3, Cuchillo.transform.eulerAngles.z));
    }
    IEnumerator DestruirOrganos()
    {
        Organos.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(Cuchilleto);
        Destroy(gameObject);

    }
    IEnumerator LaCara()
    {
        Cuchilleto.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("Estado", (Random.Range(1, 3)));
     
        yield return null;

        Cuchilleto.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetInteger("Estado", (0));
    }
    public void SiguienteFlecha()
    {
        Animadura.SetInteger("Estado", Index);
        if (Index < Flechitas.Length)
        {
            Flechitas[Index].SetActive(true);
        }
        if(Index == Flechitas.Length && !OtherThingsHappening)
        {
            print(Index);

            Cuchilleto.transform.GetChild(0).GetComponent<Animator>().SetTrigger("final");
            StartCoroutine(LaCara());
            zonaManager.InvocarPasoSiguiente(2.5f);
            canvasBocadillo.SetActive(true);
            audioEffects.Play();


            
        }
        else if(Index == Flechitas.Length)
        {
            Cuchilleto.transform.GetChild(0).GetComponent<Animator>().SetTrigger("final");
            StartCoroutine(LaCara());
            audioEffects.Play();
            StartCoroutine(DestruirOrganos());
        }
        Index++;
    }

}
