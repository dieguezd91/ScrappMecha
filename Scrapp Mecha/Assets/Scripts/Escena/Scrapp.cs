using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrapp : MonoBehaviour
{
    public float scrappToGive;
    [SerializeField] private AudioClip collectible;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.ScrappToGive(scrappToGive);
            AudioManager.instance.EjecutarSonido(collectible);
            Destroy(gameObject);
        }
    }
}
