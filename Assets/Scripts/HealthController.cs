using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float healSpeed = 10f;
    public Slider healthSlider;

    public float damageAmount = 10f; // Amount of damage to deal

    private void Start()
    {
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

    public void TakeDamage()
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0f, maxHealth);
        healthSlider.value = currentHealth;
    }
}
