using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CajaHP : MonoBehaviour
{
    public float HPToGive;
    public BarraVida barraVida;
    [SerializeField] private AudioClip hp;


    private void OnTriggerEnter2D(Collider2D other)
    {
        var vida = other.GetComponent<PlayerHealth>().HP;
        var vidaMax = other.GetComponent<PlayerHealth>().maxHP;
        barraVida.CambiarVidaActual(vida);

        if (other.CompareTag("Player") && vida < vidaMax)  
        {
            vida = other.GetComponent<PlayerHealth>().HP += (HPToGive);
            AudioManager.instance.EjecutarSonido(hp);
            barraVida.CambiarVidaActual(vida);
            Destroy(gameObject);
        }
    }
}
