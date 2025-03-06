using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredes : MonoBehaviour
{
    // Start is called before the first frame update
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(collision.collider.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    // Update is called once per frame

}
