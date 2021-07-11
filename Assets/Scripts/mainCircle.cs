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
            createSmallCircle(); // Mousun sol tu�una t�kland���nda �al��
        }
    }

    void createSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation);   // Her �al��t���nda bir yeni "smallCircle" nesnesi yarat    
        gameController.instance.smallCircleTextShow();  // 'gameController' koduna eri�ip "smallCircleTextShow" fonk. �a�r�l�r
        // Oyun ekran�ndaki 3 adet circle i�ine eklenecek olan say�lar
    }
}
