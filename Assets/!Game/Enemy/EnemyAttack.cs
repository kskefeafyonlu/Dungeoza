using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float initialDamage = 1;
    public float damage;
    private EnemyLevel levelScript;


    private void Awake() 
    {
        levelScript = GetComponent<EnemyLevel>();
        UpdateDamageWithLevel();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
        }
    }

    public void UpdateDamageWithLevel()
    {
        damage = initialDamage * levelScript.level;
    }
}






