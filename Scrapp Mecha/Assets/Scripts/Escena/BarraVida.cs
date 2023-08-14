using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider barraVida;

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        barraVida.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        barraVida.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        barraVida = GetComponent<Slider>();
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
