using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnNave;

    public GameObject NaveChefe;
    public static float pontuacaoAtual = 0;
    public float tempmin = 1;
    public float tempmax = 10;
    public static int vidas = 3;
    private float tempoSpawn;
    private float timer = 0.0f;
    private bool spawnou = false;
    void Start()
    {
        tempoSpawn = Random.Range(tempmin,tempmax); //decide quando a nave chefe vai spawnar
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnou){ //checa se ja spawnou
            timer += Time.deltaTime;
            if (timer>=tempoSpawn){ //caso nao, checa se ta na hora de spawnar
                Instantiate(NaveChefe,SpawnNave.position,transform.rotation);
                spawnou = true;
            }
            
    }
        }
        
}
