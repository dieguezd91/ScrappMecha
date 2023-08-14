using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private AudioClip explosion;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Cae", 1f);
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            Death();
        }
    }

    public void Cae()
    {
        rb2D.isKinematic = false;
    }

    private void Death()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        AudioManager.instance.EjecutarSonido(explosion);
        Destroy(gameObject);
    }
}
