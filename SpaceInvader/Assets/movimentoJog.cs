using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private Sprite leftShip;
    [SerializeField] private Sprite rightShip;
    [SerializeField] private Sprite centerShip;

    [SerializeField] private GameObject playerProjectile;

    public int lives = 3;
    public int score = 0;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    private Vector2 movement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        if (movement.x < 0) sr.sprite = leftShip;
        else if (movement.x > 0) sr.sprite = rightShip;
        else sr.sprite = centerShip; ;

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (GameObject.FindGameObjectsWithTag("PlayerProjectile").Length == 0)
        {
            Instantiate(playerProjectile, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives -= 1;
        if (lives == 0)
        {

        }
        else
        {
            // Respawn();
        }
    }

    // private void Respawn()
    // {
    //     foreach (var bullet in FindObjectsOfType<EnemyProjectile>())
    //     {
    //         Destroy(bullet.gameObject);
    //     }
    //     transform.position = new Vector3(0, -4.5f, 0);
    // }
}