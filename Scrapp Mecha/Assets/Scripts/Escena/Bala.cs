using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float damage;

    void Start()
    {
            
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Obstaculo"))
        {
            collision.GetComponent<Obstaculos>().GetDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Plataforma"))
        {
            collision.GetComponent <plataformasRompibles>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
