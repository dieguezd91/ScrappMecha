using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullajeVuelo : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float speedMovement;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;

    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Flip();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, speedMovement * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
            Flip();
        }
    }

    private void Flip()
    {
        if(transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

}
