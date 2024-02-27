using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public bool killed = false;
    [SerializeField] private float initialHealth;
    [SerializeField] private float maxHealth;
    private float health;
    private Slider healthSlider;
    

    private EnemyLevel levelScript;

    private GameObject player;

    



    private void Awake() 
    {
        levelScript = GetComponent<EnemyLevel>();
        healthSlider = GetComponentInChildren<Slider>();
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        
        UpdateHealthWithLevel();
        health = maxHealth;
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
            killed = true;
            player.GetComponent<PlayerLevel>().AddExp(levelScript.expReward);
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
    }

}
