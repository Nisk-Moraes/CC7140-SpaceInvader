using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invaders : MonoBehaviour
{
    public Transform Pontotiro;
    public GameObject Bala;
    public float pontuacao = 10; //quanto esta nave vale quando destruida
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

    void OnCollisionEnter2D(Collision2D collision) //nave eh destruida
    {
        //A FAZER! adicionar logica para aumentar ponto aqui
        GameManager.pontuacaoAtual += pontuacao;
        print(GameManager.pontuacaoAtual);
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!gameObject.CompareTag("chefe")){
            timer += Time.deltaTime;
            if (Random.Range(0,100) > 90.0f && timer>=waitTime){ //atira
                Instantiate(Bala,Pontotiro.position,transform.rotation);
            }
            
            
            if (timer >= waitTime ){ //desce y e muda de direcao
                ChangeState();
                rb2d.position = new Vector2(rb2d.position.x,rb2d.position.y-ymove);
                timer = 0.0f;
            }
        }
        
    }
}
