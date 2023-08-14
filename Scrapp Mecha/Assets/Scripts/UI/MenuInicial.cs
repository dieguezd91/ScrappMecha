using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }
    public void Play()
    {
        StartCoroutine(CambiarEscena());
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(1);
    }
}