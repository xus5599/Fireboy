using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{ 
    public float speed;

    
    

    private void Start()
    {
   
    }

    private void Update()
    {
    transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        Destroy(gameObject, 0);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0);
       
    }
}
