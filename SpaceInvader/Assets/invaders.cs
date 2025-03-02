using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    public float waitTime = 1f;
    // private int state = 0;
    private float x;
    public float ymove = 1.0f;
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        x = transform.position.x;
        // y = transform.position.y;

        var vel = rb2d.velocity;
        vel.x = speed;
        // vel.y = 0;
        rb2d.velocity = vel;
    }

    void ChangeState(){
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= waitTime){
            ChangeState();
            rb2d.position = new Vector2(rb2d.position.x,rb2d.position.y-ymove);
            timer = 0.0f;
        }
    }
}
