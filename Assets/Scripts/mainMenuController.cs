using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    public void gameStart()
    {
        int loadLevel = PlayerPrefs.GetInt("load"); // Sahnedeki level ka�sa o leveli "loadLevel" de�i�kenine atar
        if (loadLevel == 0) // E�er kay�tl� level 0 ise
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
        PlayerPrefs.DeleteAll();    // MainMenu'de F�f�rla butonuna bas�nca kay�tl� olan t�m verileri siler
    }
    public void gameExit()
    {
        Application.Quit(); //  Oyundan ��k�� yapar
    }
}
