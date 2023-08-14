using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float scrappTotal;
    public Text scrappText;    

    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        GameManager.instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        scrappText.text = "x " + scrappTotal.ToString();
    }

    public void Scrapp(float scrappCollected)
    {
        scrappTotal -= scrappCollected * Time.deltaTime;
        scrappText.text = "x " + scrappTotal.ToString();        
    }

    public void ScrappToGive(float scrappCollected)
    {
        scrappTotal += scrappCollected;
        scrappText.text = "x " + scrappTotal.ToString();
    }

}
