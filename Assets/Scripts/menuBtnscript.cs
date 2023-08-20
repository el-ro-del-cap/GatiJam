using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuBtnscript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenSubPanel(GameObject Panel)
    {
        Panel.SetActive(true);
      //gameObject.SetActive(false); //for the purpose of the cat game, self deactivation is disabled, maybe deprecate this altogether.
            
    }
    public void forceBtnSelect(Button Boton)
    {
        Boton.Select();
    }

    public void DisablePanel(GameObject panelPadre)
    {
        panelPadre.SetActive(false);
    }

    public void getout()
    {
        Application.Quit();
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


}