using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnergia : MonoBehaviour
{
    public Slider barraEnergia;

    public void CambiarEnergiaMaxima(float energiaMaxima)
    {
        barraEnergia.maxValue = energiaMaxima;
    }

    public void CambiarEnergiaActual(float cantidadEnergia)
    {
        barraEnergia.value = cantidadEnergia;
    }

    public void InicializarBarraDeEnergia (float cantidadEnergia)
    {
        barraEnergia = GetComponent<Slider>();
        CambiarEnergiaMaxima(cantidadEnergia);
        CambiarEnergiaActual(cantidadEnergia);
    }
}
