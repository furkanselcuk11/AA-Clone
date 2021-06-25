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
        physics = GetComponent<Rigidbody2D>();  // Kodun bulundu�u objenin rigibody kompenentine eri�
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
            gameController.instance.gameOver();
            // E�er smallcircle isimli taga temas ederse 'gameContoller' kodunun 'gameOver' fonk. �al��s�n
        }
    }
}
