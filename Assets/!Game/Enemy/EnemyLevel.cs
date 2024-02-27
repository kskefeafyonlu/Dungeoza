using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel : MonoBehaviour
{
    public int level = 1;
    public float initialExpReward = 1f;
    [HideInInspector]
    public float expReward = 1f;


    EnemyHealth healthScript;
    EnemyMovement movementScript;
    EnemyAttack attackScript;


    private void Start() 
    {
        healthScript = GetComponent<EnemyHealth>();
        movementScript = GetComponent<EnemyMovement>();
        attackScript = GetComponent<EnemyAttack>();


        UpdateEnemyAttributes();
    }



    public void UpdateEnemyAttributes()
    {
        healthScript.UpdateHealthWithLevel();
        attackScript.UpdateDamageWithLevel();

        expReward = initialExpReward * level;
    }
}
