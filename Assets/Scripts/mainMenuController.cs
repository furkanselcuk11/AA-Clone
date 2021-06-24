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
            SceneManager.LoadScene(loadLevel+1); // E�er daha �nce kay�tl� level yoksa 1. leveli a�ar
        }
        else
        {
            SceneManager.LoadScene(loadLevel); // Kay�tl� leveli a�ar
        }
        
    }
    public void gameDelete()
    {
        PlayerPrefs.DeleteAll();
    }
    public void gameExit()
    {
        Debug.Log("��kt�");
        Application.Quit();
    }
}
