using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float gameTime;
    public Decimal gameTimeDec;
    private TextMeshProUGUI tessto;
    // Start is called before the first frame update
    void Start()
    {
        tessto = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += 1*Time.deltaTime;
        gameTimeDec = decimal.Truncate(Convert.ToDecimal(gameTime));
        tessto.text = gameTimeDec.ToString();
    }
}
