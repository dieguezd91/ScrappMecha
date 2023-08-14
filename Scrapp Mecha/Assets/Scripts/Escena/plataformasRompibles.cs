using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformasRompibles : MonoBehaviour
{
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


    private void Death()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        AudioManager.instance.EjecutarSonido(explosion);
        Destroy(gameObject);
    }
}
