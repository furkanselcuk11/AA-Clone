using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turningController : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime); // Obejeyi Z ekseninde döndürür 
    }
}
