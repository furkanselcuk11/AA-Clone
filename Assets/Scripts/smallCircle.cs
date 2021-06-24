using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCircle : MonoBehaviour
{
    Rigidbody2D physics;
    public float speed;
    bool moveControl=false;

    GameObject gameControllerObject;    // obje deðiþkeni tanýmla
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();  // Kodun bulunduðu objenin rigibody kompenentine eriþ
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");  // Belirtilen tag ismini bulup deðiþkene ata
    }    
     void FixedUpdate()
    {
        if (!moveControl)
        {
            physics.MovePosition(physics.position + Vector2.up * speed * Time.deltaTime);   // Obje ileri doðru hareket eder
        }        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "turningcircle")
        {
            transform.SetParent(collision.transform);   // Çarpýlan objenin çocuðu olur
            moveControl = true;
        }
        if (collision.tag == "smallcircle")
        {
            gameControllerObject.GetComponent<gameController>().gameOver(); 
            // Eðer smallcircle isimli taga temas ederse GameContoller objesinin 'gameContoller' kodunun 'gameOver' fonk. çalýþsýn
        }
    }
}
