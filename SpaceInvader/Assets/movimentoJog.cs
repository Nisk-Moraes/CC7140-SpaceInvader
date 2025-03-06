using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class movimentoJog : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Transform Pontotiro;

    public GameObject Bala;
    

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode shoot = KeyCode.Space;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private float timer = 0.0f;
    public float waitTime = 1.0f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        GameManager.vidas -=1;
        print(GameManager.vidas);
        if (GameManager.vidas <0){
            //fim do jogo, acabou vidas do player
            spriteRenderer.sprite = newSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        timer += Time.deltaTime;
        if (GameManager.vidas >=0 ){
            if (Input.GetKey(shoot) && timer >= waitTime){
                timer = 0.0f;
                Instantiate(Bala,Pontotiro.position,transform.rotation);
            }

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
}
