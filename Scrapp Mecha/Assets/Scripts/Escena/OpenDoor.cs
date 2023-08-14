using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private int cantidadEnemigos;

    public GameObject victoria;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
    }

    public void ActivarPuerta()
    {
        animator.SetTrigger("Activar");
    }

    public void EnemigoEliminado()
    {
        cantidadEnemigos -= 1;

        if(cantidadEnemigos == 0)
        {
            ActivarPuerta();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && cantidadEnemigos == 0)
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
        }
    }
}
