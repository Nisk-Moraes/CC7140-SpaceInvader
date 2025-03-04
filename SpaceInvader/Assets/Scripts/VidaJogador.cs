using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJogador : MonoBehaviour
{
    public int vidaPlayer = 3;
    public int vidaAtual;
    public GameObject[] vidaIcons;  // Array para armazenar os ícones de vida

    void Start()
    {
        vidaAtual = vidaPlayer;
    }

    public void tiraVida()
    {
        if (vidaAtual > 0)
        {
            vidaAtual -= 1;
            Debug.Log(vidaIcons.Length);
            if (vidaAtual <= vidaIcons.Length)
            {
                vidaIcons[vidaAtual].SetActive(false);  // Desativa o ícone correspondente
            }
        }

        if (vidaAtual <= 0)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("Loser");
        }
    }
}
