using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; 
    public GUISkin layout;
    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    public float enemySpeedMultiplier = 1.0f; 

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Fase1")
            {
                PlayerScore1 = 0;
            }
            else
            {
                // Carrega a pontuação salva
                PlayerScore1 = PlayerPrefs.GetInt("PlayerScore", 0);
            }
    }

    public void AddScore(int points)
    {
        PlayerScore1 += points;

        if (GameObject.FindGameObjectsWithTag("0").Length == 0 &&
            GameObject.FindGameObjectsWithTag("1").Length == 0 &&
            GameObject.FindGameObjectsWithTag("2").Length == 0 &&
            GameObject.FindGameObjectsWithTag("3").Length == 0)
        {
            IncreaseEnemySpeed();
            LoadNextLevel();
        }
    }

    void IncreaseEnemySpeed()
    {
        enemySpeedMultiplier += 0.5f; 
    }

    void LoadNextLevel()
    {
        // Salva a pontuação antes de carregar a nova fase
        PlayerPrefs.SetInt("PlayerScore", PlayerScore1);
        PlayerPrefs.Save(); // Salva as mudanças

        // Carrega a próxima cena
        string currentScene = SceneManager.GetActiveScene().name; 
        if (currentScene == "Fase1")
        {
            SceneManager.LoadScene("Fase2");
        }
        else if (currentScene == "Fase2")
        {
            SceneManager.LoadScene("Victoria");
        }

        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(0.1f); // Espera um pouco para a nova cena carregar

        Invaders[] invaders = FindObjectsOfType<Invaders>();
        foreach (Invaders invader in invaders)
        {
            if (SceneManager.GetActiveScene().name == "Fase2")
            {
                invader.waitTime = 0.3f; // Alterar diretamente
                invader.moveSpeedHorizontal = 1.5f; // Alterar diretamente
                Debug.Log("Variáveis de fase 2 alteradas.");
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 40, 100, 100), "Score: " + PlayerScore1);
    }
}
