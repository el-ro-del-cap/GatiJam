using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgCycler : MonoBehaviour
{
    public Sprite[] imgs;
    public int count;
    private Image pana;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        pana = gameObject.GetComponent<Image>();
        Debug.Log(imgs.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cycle()
    {
        if (count >= imgs.Length-1)
        {
            count = 0;
            pana.sprite = imgs[count];
        }
        else
        {
            count++;
            pana.sprite = imgs[count];
        }


    }
}
