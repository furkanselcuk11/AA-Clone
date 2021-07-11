using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCircle : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed; // Fýrlatýlan çubuðun hýzý
    bool moveControl=false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Kodun bulunduðu objenin rigibody kompenentine eriþ
    }    
     void FixedUpdate()
    {
        if (!moveControl)
        {   // Nesne ileri doðru hareket eder
            //rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);   // 1.Yol
            transform.Translate(0, speed * Time.fixedDeltaTime,0); // 2. Yol
        }        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "turningcircle")
        {
            transform.SetParent(collision.transform);   // Çarpýlan nesnenin alt çocuðu olur ve onunla birlikte döner
            moveControl = true;
        }
        if (collision.tag == "smallcircle")
        {
            gameController.instance.gameOver(); 
            // Eðer "smallCircle" nesnesi baþka bir "smallCircle" taglý nesneye çarparsa "gameOver" fonk. çalýþýr
        }
    }
}
