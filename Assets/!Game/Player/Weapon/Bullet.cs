using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 1f;
    public float speed = 10f;
    public float life = 3f;

    

    private void Start() {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
        if(other.transform.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }
    }




}
