using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoJog : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode shoot = KeyCode.Space;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;

        if (Input.GetKey(moveUp))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }

        rb2d.velocity = vel;

        var pos = transform.position;

        if (pos.x > boundY)
        {
            pos.x = boundY;
        }
        else if (pos.x < -boundY)
        {
            pos.x = -boundY;
        }

        transform.position = pos;
    }
}
