using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

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
        _instance = this;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + healSpeed * Time.deltaTime, 0f, maxHealth);
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        healthSlider.value = currentHealth;
    }
}
