using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnNave;
    public Transform SpawnTela;

    public GameObject NaveChefe;
    public GameObject TelaVitoria;
    public GameObject TelaDerrota;
    public GUISkin layout;
    public static float pontuacaoAtual = 0;
    public float pontuacaoFinal = 300;
    public static bool invadiram = false;
    public static bool derrota = false;
    public static bool vitoria = false;
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
    void Derrota(){
        Instantiate(TelaDerrota,SpawnTela.position,transform.rotation);
    }
    void Vitoria(){
        Instantiate(TelaVitoria,SpawnTela.position,transform.rotation);
    }
    void Wipe(){
        var inimigos = GameObject.FindGameObjectsWithTag("inimigo");
        for(int i = 0; i < inimigos.Length; ++i){
            Destroy(inimigos[i]);
        }
    }
    async Task OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 250 - 12, 40, 200, 100), "Score: " + pontuacaoAtual);
        GUI.Label(new Rect(Screen.width / 2 - 250 - 12, 50, 200, 100), "Vidas: " + GameManager.vidas);
        
        
    }
    bool MatouTudo(){
        var inimigos = GameObject.FindGameObjectsWithTag("inimigo");
        if (inimigos.Length == 0){
            return true;
        }
        return false;
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
        if ((pontuacaoAtual >= pontuacaoFinal) && !vitoria){
            vitoria = true;
            Vitoria();
            Wipe();
        }
        if ((vidas <0 || invadiram) && !derrota){
            derrota = true;
            Derrota();
            Wipe();
        }
        
    }
        
}
