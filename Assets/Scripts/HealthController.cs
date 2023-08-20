using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

    public GameObject Pana;
    public Animator BarAnim;
    public Animator TextAnim;
    private AudioSource Knock;

    private static HealthController _instance;
    public static HealthController Instance {
        get {
            return _instance;
        }
    }

    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float healSpeed = 2f;
    public Slider healthSlider;

    //public float damageAmount = 10f; // Amount of damage to deal

    private void Start() {
        Knock = gameObject.GetComponent<AudioSource>();
        _instance = this;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public IEnumerator Muerte()
    {
        Knock.Play();
        Pana.SetActive(true);
        BarAnim.SetTrigger("Death");
        TextAnim.SetTrigger("Death");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + healSpeed * Time.deltaTime, 0f, maxHealth);
            healthSlider.value = currentHealth;
        }
        if (currentHealth < 1)
        {
            StartCoroutine("Muerte");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        healthSlider.value = currentHealth;
    }
    
   

}
