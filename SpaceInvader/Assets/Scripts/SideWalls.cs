using UnityEngine;
using System.Collections;
public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Player")
        //if(hitInfo.gameObject.CompareTag("Ball"))
        {
            string wallName = transform.name;
            hitInfo.gameObject.GetComponent<VidaJogador>().tiraVida();
        }
    }
}
