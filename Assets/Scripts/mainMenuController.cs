using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    public void gameStart()
    {
        int loadLevel = PlayerPrefs.GetInt("load");
        if (loadLevel == 0)
        {
            SceneManager.LoadScene(loadLevel+1); // Eðer daha önce kayýtlý level yoksa 1. leveli açar
        }
        else
        {
            SceneManager.LoadScene(loadLevel); // Kayýtlý leveli açar
        }
        
    }
    public void gameDelete()
    {
        PlayerPrefs.DeleteAll();
    }
    public void gameExit()
    {
        Debug.Log("Çýktý");
        Application.Quit();
    }
}
