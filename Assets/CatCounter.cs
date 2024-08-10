using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class CatCounter : MonoBehaviour
{
    public TextMeshProUGUI textCounter;
    public int CatsFed;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        textCounter = gameObject.GetComponent<TextMeshProUGUI>();
        CatsFed = 0;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
            counterReset();
    }
    public void counterAdd()
    {
        CatsFed++;
        textCounter.text = CatsFed.ToString();
    }
    public void counterReset()
    {
        CatsFed = 0;
        textCounter.text = CatsFed.ToString();
    }
}

