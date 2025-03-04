using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se colidiu com o jogador
        {
            // Chama a função para tirar vida do jogador
            other.GetComponent<VidaJogador>().tiraVida();

            // Destroi o projétil após a colisão
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        // Destroi o projétil se sair da tela
        Destroy(gameObject);
    }
}