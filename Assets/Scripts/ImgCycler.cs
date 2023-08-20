using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgCycler : MonoBehaviour
{
    public Sprite img1;
    public Sprite Img2;
    private Image pana;
    // Start is called before the first frame update
    void Start()
    {
        pana = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cycle()
    {
        if (pana.sprite = img1) 
            pana.sprite = Img2;
        else if (pana.sprite = Img2) 
            pana.sprite = img1;
    }
}
