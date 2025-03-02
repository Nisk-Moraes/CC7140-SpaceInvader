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
    // Update is called once per frame
   
}
