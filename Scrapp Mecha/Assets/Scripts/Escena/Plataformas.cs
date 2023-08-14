using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public List<GameObject> plataformas;

    private PlayerController playerController;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.OnJump += Activar;
    }

    private void Activar(object sender, EventArgs e)
    {
        foreach (GameObject item in plataformas)
        {
            item.SetActive(!item.activeSelf);
        }
    }
}
