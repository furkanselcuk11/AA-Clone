using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    GameObject turningCircleObj;    // Oyun sahnesinde levelin yaz�l� oldu�u d�ner �ember
    GameObject mainCircleObj;   // At�lacak �ucuklar�n oldu�u �ember
    public Animator animator;
    public Text turningCircleText; // �ember i�inde yaz�l� olan textler - Ka� adet �ubuk kald���n� g�sterir

    public Text one, two, three;
    public int totalCircle; // Toplam �ubuklar

    bool gameOverControl = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayerPrefs.SetInt("load",SceneManager.GetActiveScene().buildIndex);    // Oyunun en sonki levelini kay�t eder - Tekrar ayn� leveli a�mak i�in

        turningCircleObj = GameObject.FindGameObjectWithTag("turningcircle");   // Belirtilen tag ismini bulup de�i�kene ata
        mainCircleObj = GameObject.FindGameObjectWithTag("maincircle");
        turningCircleText.text = SceneManager.GetActiveScene().buildIndex+"";    // Hangi level'de oldu�unu d�nen �embere yazar
        //turningCircleText.text = SceneManager.GetActiveScene().name;    // Hangi level'de oldu�unu ��renir

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
        // Bir sonraki levele ge�i�te - at�lacak �ubuk kalmad���nda
        turningCircleObj.GetComponent<turningController>().enabled = false; // �ember d�nd�rme kompenetine eri� ve �al��mas�n� durdur
        mainCircleObj.GetComponent<mainCircle>().enabled = false;   // �ubuk atma kompenetine eri� ve �al��mas�n� durdur
        yield return new WaitForSeconds(0.3f);

        if (gameOverControl)    // E�er oyunda yanmam��san yeni levele ge�
        {
            animator.SetTrigger("nextlevel");    // Yeni levele ge�ti�inde 'nexetlevel' animasyonunu �al��t�r
            yield return new WaitForSeconds(1.5f); // Animasyondan sonra 1 saniye beklet
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(1); // E�er son level ge�ilmisse ilk levele d�n
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // Bir sonraki levele ge�
            }
            
        }        
    }

    public void gameOver()
    {
        StartCoroutine(gameOverMethod());   // IEnumerator fonk. �a��r�r
    }
    IEnumerator gameOverMethod()
    {
        turningCircleObj.GetComponent<turningController>().enabled = false; // �ember d�nd�rme kompenetine eri� ve �al��mas�n� durdur
        mainCircleObj.GetComponent<mainCircle>().enabled = false;   // Ok atma kompenetine eri� ve �al��mas�n� durdur

        animator.SetTrigger("gameover");    // Oyun bitti�inde 'gameover' animasyonunu �al��t�r
        gameOverControl = false;
        yield return new WaitForSeconds(1.5f); // Animasyondan sonra 1 saniye beklet

        SceneManager.LoadScene("MainMenu"); // Anamen�y� a�ar
    }
}
