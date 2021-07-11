using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCircle : MonoBehaviour
{
    public GameObject smallCircle;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // Input.GetButtonDown("0")
        {
            createSmallCircle(); // Mousun sol tuþuna týklandýðýnda çalýþ
        }
    }

    void createSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation);   // Her çalýþtýðýnda bir yeni "smallCircle" nesnesi yarat    
        gameController.instance.smallCircleTextShow();  // 'gameController' koduna eriþip "smallCircleTextShow" fonk. çaðrýlýr
        // Oyun ekranýndaki 3 adet circle içine eklenecek olan sayýlar
    }
}
