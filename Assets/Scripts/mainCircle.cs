using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCircle : MonoBehaviour
{
    public GameObject smallCircle;
    GameObject gameControllerObj;
    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController"); // Belirtilen tag ismini bulup deðiþkene ata
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // Mousun sol tuþuna týklandýðýnda çalýþ
        {
            createSmallCircle();
        }
    }

    void createSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation);   // Her çalýþtýðýnda bir yeni obje yarat
    // GameController objesinden 'gameController' koduna eriþip samaltestshow fonk. çaðrýlýr
        gameControllerObj.GetComponent<gameController>().smallCircleTextShow(); 
    }
}
