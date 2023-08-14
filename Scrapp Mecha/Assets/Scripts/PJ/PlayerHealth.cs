using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float HP;
    public float maxHP;

    [SerializeField] private BarraVida barraVida;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private GameObject deathEffect;

    public event EventHandler<OnTakeDamageEventArgs> OnTakeDamage;
    public event EventHandler MuerteJugador;

    private PlayerController playerController;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    public class OnTakeDamageEventArgs: EventArgs
    {
        public float cantidadVida;
    }


    void Start()
    {
        HP = maxHP;
        barraVida.InicializarBarraDeVida(HP);
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }

    public void TomarDaño(float daño, Vector2 vector2)
    {
        HP -= daño;
        animator.SetTrigger("Hit");
        StartCoroutine(PerderControl());
        StartCoroutine(Inmunity());
        playerController.Rebote(vector2);
        barraVida.CambiarVidaActual(HP);
        OnTakeDamage?.Invoke(this, new OnTakeDamageEventArgs {cantidadVida = HP});        
        if (HP <= 0)
            {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            AudioManager.instance.EjecutarSonido(explosion);
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    private IEnumerator PerderControl()
    {
        playerController.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        playerController.sePuedeMover = true;
    }

    private IEnumerator Inmunity()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
