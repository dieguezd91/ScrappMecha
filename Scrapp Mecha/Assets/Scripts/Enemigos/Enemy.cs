using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] private float HP;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private GameObject deathEffect;


    public void GetDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                other.gameObject.GetComponent<PlayerHealth>().TomarDaño(33, other.GetContact(0).normal);
            }
        }   
    }

    private void Death()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("Puerta").GetComponent<OpenDoor>().EnemigoEliminado();
        AudioManager.instance.EjecutarSonido(explosion);
        Destroy(gameObject);
    }

}
