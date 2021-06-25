using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCircle : MonoBehaviour
{
    public GameObject smallCircle;
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
        gameController.instance.smallCircleTextShow();  // 'gameController' koduna eri�ip smallCircleTextShow fonk. �a�r�l�r
    }
}
