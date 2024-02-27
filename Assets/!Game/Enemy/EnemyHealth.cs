using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    private Slider healthSlider;
    private EnemyLevel levelScript;



    private void Awake() 
    {
        levelScript = GetComponent<EnemyLevel>();
        healthSlider = GetComponentInChildren<Slider>();
    }

    void Start()
    {
        UpdateHealthBar();
        UpdateHealthWithLevel();
        health = maxHealth;
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


    public void UpdateHealthWithLevel()
    {
        maxHealth = initialHealth * levelScript.level;
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
