using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    private Slider healthSlider;



    private void Awake() 
    {
        health = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
        UpdateHealthBar();
    }

    void Start()
    {
        UpdateHealthBar();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Damage(1);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Heal(1);
        }
    }



    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
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


    private void LerpChange()
    {

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
    }

}
