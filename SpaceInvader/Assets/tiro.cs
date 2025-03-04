using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel = 2.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (gameObject.CompareTag("inimigo"))
        {
            rb2d.velocity = transform.up*-vel;
        }
        else{
            rb2d.velocity =transform.up*vel;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
