using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;


    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    

    private void Awake() 
    {
        health = maxHealth;
    }

    private void Start() 
    {
        healthSlider = GetComponentInChildren<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateHealthBar();
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            
        }
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {
        if(health == maxHealth)
        {
            healthSlider.gameObject.SetActive(false);
            
        }
        else
        {
            healthSlider.gameObject.SetActive(true);
        }
        healthSlider.value = health/maxHealth;
        healthText.text = $"{health} | {maxHealth}";
    }

    
    
}
