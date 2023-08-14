using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajaEnergia : MonoBehaviour
{
    private float EnergyToGive = 1;
    public BarraEnergia barraEnergia;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var scrappCollected = GameManager.instance.scrappTotal;
        var maxCombustible = collision.GetComponent<PlayerController>().maxCombustible;
        var combustible = collision.GetComponent<PlayerController>().combustible;
        barraEnergia.CambiarEnergiaActual(combustible);

        if (collision.CompareTag("Player") && scrappCollected >= 0.1 && combustible < maxCombustible)
        {
            combustible = collision.GetComponent<PlayerController>().combustible += EnergyToGive * Time.deltaTime * 30;
            barraEnergia.CambiarEnergiaActual(combustible);
            GameManager.instance.Scrapp(scrappCollected);
            Debug.Log("cargando");
        }
    }


}