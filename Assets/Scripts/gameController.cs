using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    GameObject turningCircleObj;
    GameObject mainCircleObj;
    public Animator animator;
    public Text turningCircleText;

    public Text one, two, three;
    public int totalCircle;

    bool gameOverControl = true;
    void Start()
    {
        PlayerPrefs.SetInt("load",SceneManager.GetActiveScene().buildIndex);    // Oyunun en sonki levelini kayýt eder - Tekrar ayný leveli açmak için

        turningCircleObj = GameObject.FindGameObjectWithTag("turningcircle");   // Belirtilen tag ismini bulup deðiþkene ata
        mainCircleObj = GameObject.FindGameObjectWithTag("maincircle");
        turningCircleText.text = SceneManager.GetActiveScene().buildIndex+"";    // Hangi level'de olduðunu dönen çembere yazar
        //turningCircleText.text = SceneManager.GetActiveScene().name;    // Hangi level'de olduðunu öðrenir

        if (totalCircle < 2)
        {
            one.text = totalCircle + "";
        }
        else if (totalCircle < 3)
        {
            one.text = totalCircle + "";
            two.text = (totalCircle - 1) + "";
        }
        else
        {
            one.text = totalCircle + "";
            two.text = (totalCircle-1) + "";
            three.text = (totalCircle-2) + "";
        }
    }

    public void smallCircleTextShow()
    {
        totalCircle--;
        if (totalCircle < 2)
        {
            one.text = totalCircle + "";
            two.text = "";
            three.text = "";
        }
        else if (totalCircle < 3)
        {
            one.text = totalCircle + "";
            two.text = (totalCircle - 1) + "";
            three.text = "";
        }
        else
        {
            one.text = totalCircle + "";
            two.text = (totalCircle - 1) + "";
            three.text = (totalCircle - 2) + "";
        }
        if (totalCircle == 0)
        {
            StartCoroutine(nextLevel());
        }
    }

    IEnumerator nextLevel()
    {
        turningCircleObj.GetComponent<turningController>().enabled = false; // Oyun bittiðinde oyun üzerindeki objenin kompenete eriþ ve çalýþmasýný durdur
        mainCircleObj.GetComponent<mainCircle>().enabled = false;
        yield return new WaitForSeconds(0.3f);

        if (gameOverControl)    // Eðer oyunda yanmamýþsan yeni levele geç
        {
            animator.SetTrigger("nextlevel");    // Yeni levele geçtiðinde 'nexetlevel' animasyonunu çalýþtýr
            yield return new WaitForSeconds(1.5f); // Animasyondan sonra 1 saniye beklet
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // Þuan ki levelin 1 fazlasý olan leveli aç
        }        
    }

    public void gameOver()
    {
        StartCoroutine(gameOverMethod());   // IEnumerator fonk. çaðýrýr
    }
    IEnumerator gameOverMethod()
    {
        turningCircleObj.GetComponent<turningController>().enabled = false; // Oyun bittiðinde oyun üzerindeki objenin kompenete eriþ ve çalýþmasýný durdur
        mainCircleObj.GetComponent<mainCircle>().enabled = false;

        animator.SetTrigger("gameover");    // Oyun bittiðinde 'gameover' animasyonunu çalýþtýr
        gameOverControl = false;
        yield return new WaitForSeconds(1.5f); // Animasyondan sonra 1 saniye beklet

        SceneManager.LoadScene("MainMenu"); // Anamenüyü açar
    }
}
