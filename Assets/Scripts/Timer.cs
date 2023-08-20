using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private float gameTime;
    private TextMeshProUGUI tessto;

    void Awake()
    {
        tessto = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        gameTime += 1*Time.deltaTime;
        tessto.text = Math.Round(gameTime, 2).ToString(); //gameTimeDec.ToString(); 
    }
}
