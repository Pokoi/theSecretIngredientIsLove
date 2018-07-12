using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private GameObject canvasSettings;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void nextScene()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void playGame()
    {
        Invoke("loadGameScene", 1.5f);
    }

    void loadGameScene()
    {

        SceneManager.LoadScene("scene_01");

    }
}

    
