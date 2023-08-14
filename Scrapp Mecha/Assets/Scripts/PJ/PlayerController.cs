using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;

    [Header("Movimiento")]

    private float walking = 0f;
    [SerializeField] private float speedMovement;
    [Range (0, 0.3f)][SerializeField] private float smoothMovement;
    private Vector3 speed = Vector3.zero;
    public bool walksRight = true;

    [Header("Salto")]

    [SerializeField] private float jumpForce;
    [SerializeField] private float flyForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector3 boxDimensions;

    [SerializeField] private bool isGrounded;

    public bool jump;

    [Header("Animacion")]

    private Animator animator;

    [Header("Disparos")]
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;


    [Header("Sonidos")]
    [SerializeField] private AudioClip vuelo;
    [SerializeField] private AudioClip shoot;

    [SerializeField] private BarraEnergia barraEnergia;

    public float combustible;
    public float maxCombustible;

    private bool isFlying;

    public event EventHandler OnJump;

    private SpriteRenderer spriteRenderer;

    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        combustible = maxCombustible;
        barraEnergia.InicializarBarraDeEnergia(combustible);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxDimensions, 0f, whatIsGround);

        //MOVIMIENTO
        walking = Input.GetAxisRaw("Horizontal") * speedMovement;
        

        //ACTIVACION DE LA ANIMACION MOVIMIENTO
        if (walking != 0)
            animator.SetBool("isWalking", true);            
        else animator.SetBool("isWalking", false);


        //SALTO
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            jump = true;
            isGrounded = false;
            OnJump?.Invoke(this, EventArgs.Empty);
        }

        //VUELO
        if (Input.GetKey(KeyCode.W) && !isGrounded && combustible > 0) 
        {            
            rb2D.velocity = transform.up * flyForce;
            animator.SetBool("isFlying", true);
            animator.SetBool("isJumping", false);
            AudioManager.instance.EjecutarSonido(vuelo);
            combustible -= Time.deltaTime * 20;            
            barraEnergia.CambiarEnergiaActual(combustible);
            jump = false;
            if ( combustible <= 0)
                {
                    combustible = 0;
                    rb2D.gravityScale = 5;
                    animator.SetBool("isFlying", false);
                    animator.SetBool("Idle", true);
                    rb2D.gravityScale = 2;
                }
        }


        //DISPARO
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
            AudioManager.instance.EjecutarSonido(shoot);
        }

        if (combustible > maxCombustible)
        {
            combustible = maxCombustible;
        }
    }

    private void FixedUpdate()
    {
        if(sePuedeMover)
        {
            Walk(walking * Time.fixedDeltaTime);
        }
    }

    private void Walk(float walk)
    {
        //SUAVIZADO DE MOVIMIENTO
        Vector3 speedTarget = new Vector2(walk, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, speedTarget, ref speed, smoothMovement);
        
        //GIRO DE PERSONAJE
        if (walk > 0 && !walksRight)
        {
            Flip();
        }
        else if (walk < 0 && walksRight)
        {
            Flip();
        }
    }


    //SI EL JUGADOR ESTA COLISIONANDO CON LA CAPA 6 (PISO) LAS ANIMACIONES NO SE ACTIVAN
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            jump = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFlying", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, boxDimensions);
    }

    private void Flip()
    {
        walksRight = !walksRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void ShootBullet()
    {
        if (walksRight)
        {
            Instantiate(bala, controladorDisparo.position, Quaternion.Euler(0, 0, 0));
        }
        else if (!walksRight)
        {
            Instantiate(bala, controladorDisparo.position, Quaternion.Euler(0, 0, -180));
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb2D.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }
}
