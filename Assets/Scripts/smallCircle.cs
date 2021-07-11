using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCircle : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed; // F�rlat�lan �ubu�un h�z�
    bool moveControl=false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Kodun bulundu�u objenin rigibody kompenentine eri�
    }    
     void FixedUpdate()
    {
        if (!moveControl)
        {   // Nesne ileri do�ru hareket eder
            //rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);   // 1.Yol
            transform.Translate(0, speed * Time.fixedDeltaTime,0); // 2. Yol
        }        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "turningcircle")
        {
            transform.SetParent(collision.transform);   // �arp�lan nesnenin alt �ocu�u olur ve onunla birlikte d�ner
            moveControl = true;
        }
        if (collision.tag == "smallcircle")
        {
            gameController.instance.gameOver(); 
            // E�er "smallCircle" nesnesi ba�ka bir "smallCircle" tagl� nesneye �arparsa "gameOver" fonk. �al���r
        }
    }
}
