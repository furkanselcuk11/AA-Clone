using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    public void gameStart()
    {
        int loadLevel = PlayerPrefs.GetInt("load"); // Sahnedeki level kaçsa o leveli "loadLevel" deðiþkenine atar
        if (loadLevel == 0) // Eðer kayýtlý level 0 ise
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
        PlayerPrefs.DeleteAll();    // MainMenu'de Fýfýrla butonuna basýnca kayýtlý olan tüm verileri siler
    }
    public void gameExit()
    {
        Application.Quit(); //  Oyundan çýkýþ yapar
    }
}
