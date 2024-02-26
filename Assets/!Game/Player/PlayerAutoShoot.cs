using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAutoShoot : MonoBehaviour
{
    
    private Transform playerTransform;
    private Rigidbody2D playerRB;
    private GameObject[] enemyList;

    private float distance;
    private float nearestDistance;

    GameObject closestEnemy;


    public GameObject bullet;
    public float cooldown = 1f;
    public float countCool = 0f;
    
        


   



    private void Start() 
    {
        playerTransform = transform;
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if (countCool > cooldown)
        {
            ShootAtNearestEnemy();
            countCool = 0;
        }
        else
        {
            countCool += Time.deltaTime;
        }

        
    }



    private void ShootAtNearestEnemy()
    {
        FindNearestEnemy();
        if (closestEnemy != null)
        {
            Shoot(closestEnemy.transform);
        }
    }


    public void Shoot(Transform targetTransform)
    {
        Vector2 dir2target = new Vector2(targetTransform.position.x - transform.position.x, targetTransform.position.y - transform.position.y);
        
        float rotDegrees = Mathf.Atan2(dir2target.y, dir2target.x) * Mathf.Rad2Deg;

        var bulletObject = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);

        bulletObject.transform.rotation = Quaternion.Euler(0, 0, rotDegrees);
        bulletObject.GetComponent<Rigidbody2D>().velocity = dir2target.normalized * bullet.GetComponent<Bullet>().speed;

    }







    private void FindNearestEnemy()
    {
        
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        


        if (enemyList.Length != 0){
            closestEnemy = enemyList[0];
            nearestDistance = Vector3.Distance(transform.position, closestEnemy.transform.position);
        }
        else{
            return;
        }
        

        for (int i = 0; i < enemyList.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, enemyList[i].transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                closestEnemy = enemyList[i];
            }
        }
    }
}
