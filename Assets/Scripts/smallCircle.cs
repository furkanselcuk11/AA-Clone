using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCircle : MonoBehaviour
{
    Rigidbody2D physics;
    public float speed;
    bool moveControl=false;

    GameObject gameControllerObject;    // obje de�i�keni tan�mla
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();  // Kodun bulundu�u objenin rigibody kompenentine eri�
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");  // Belirtilen tag ismini bulup de�i�kene ata
    }    
     void FixedUpdate()
    {
        if (!moveControl)
        {
            physics.MovePosition(physics.position + Vector2.up * speed * Time.deltaTime);   // Obje ileri do�ru hareket eder
        }        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "turningcircle")
        {
            transform.SetParent(collision.transform);   // �arp�lan objenin �ocu�u olur
            moveControl = true;
        }
        if (collision.tag == "smallcircle")
        {
            gameControllerObject.GetComponent<gameController>().gameOver(); 
            // E�er smallcircle isimli taga temas ederse GameContoller objesinin 'gameContoller' kodunun 'gameOver' fonk. �al��s�n
        }
    }
}
