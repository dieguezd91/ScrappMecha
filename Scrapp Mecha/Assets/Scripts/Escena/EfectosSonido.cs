using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosSonido : MonoBehaviour
{
    [SerializeField] private AudioClip vuelo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.instance.EjecutarSonido(vuelo);
            Destroy(gameObject);
        }
    }
}
