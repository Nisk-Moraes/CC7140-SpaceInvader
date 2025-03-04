using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.A;  // Movimento para a direita
    public KeyCode moveLeft = KeyCode.D;   // Movimento para a esquerda
    public float speed = 10.0f;

    // Limites de movimento
    public float boundX = 5.0f;
    private Rigidbody2D rb2d;

    // Parâmetros para o tiro
    public GameObject projectilePrefab;    // Prefab do projétil
    public Transform Firee;                // Ponto de origem do tiro
    public float projectileSpeed = 10.0f;  // Velocidade do projétil

    // Som do tiro
    public AudioClip shootSound;           // Arquivo de som do tiro
    private AudioSource audioSource;       // Componente para reproduzir o som

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // Obtém o componente de áudio
    }

    void Update()
    {
        // Movimento horizontal do player
        var vel = rb2d.velocity;

        if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }

        rb2d.velocity = vel;

        var pos = transform.position;

        if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        transform.position = pos;

        // Atirar quando a tecla Espaço for pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar o projétil no Firee e adicionar força para ele se mover para cima
        GameObject projectile = Instantiate(projectilePrefab, Firee.position, Quaternion.identity);
        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = Vector2.up * projectileSpeed;  // Movimenta o projétil para cima

        // Tocar som de tiro
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);  // Reproduz o som do tiro
        }
    }
}
