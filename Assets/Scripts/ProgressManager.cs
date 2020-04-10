using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("LvlStart");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resetprogress()
    {
        PlayerPrefs.SetInt("LvlStart", 0);
        currentLevel = PlayerPrefs.GetInt("LvlStart");
        //this is used for playtesting and allows us to reset the game to first position
    }

    public void GameStart()
    {
        if (currentLevel == 0)
        {
            SceneManager.LoadScene("LoadingScene"); //LoadingScene loads up the Tutorial

        }

        else if (currentLevel== 1)
        {
            SceneManager.LoadScene("LoadingScene2"); //LoadingScene 2 loads up the first level
        }
    }

}
