using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCircle : MonoBehaviour
{
    public GameObject smallCircle;
    GameObject gameControllerObj;
    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController"); // Belirtilen tag ismini bulup de�i�kene ata
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // Mousun sol tu�una t�kland���nda �al��
        {
            createSmallCircle();
        }
    }

    void createSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation);   // Her �al��t���nda bir yeni obje yarat
    // GameController objesinden 'gameController' koduna eri�ip samaltestshow fonk. �a�r�l�r
        gameControllerObj.GetComponent<gameController>().smallCircleTextShow(); 
    }
}
