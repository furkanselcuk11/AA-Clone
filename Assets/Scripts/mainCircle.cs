using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCircle : MonoBehaviour
{
    public GameObject smallCircle;
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
        gameController.instance.smallCircleTextShow();  // 'gameController' koduna eriþip smallCircleTextShow fonk. çaðrýlýr
    }
}
