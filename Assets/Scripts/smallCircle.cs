using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCircle : MonoBehaviour
{
    Rigidbody2D physics;
    public float speed;
    bool moveControl=false;
    
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();  // Kodun bulunduðu objenin rigibody kompenentine eriþ
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
            gameController.instance.gameOver();
            // Eðer smallcircle isimli taga temas ederse 'gameContoller' kodunun 'gameOver' fonk. çalýþsýn
        }
    }
}
