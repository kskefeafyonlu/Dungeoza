using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] GameObject bullet;
    Rigidbody2D bulletRB;
    private float coolTime = 0f;
    public float cooldownTime = 1f;

    private void Update() 
    {
        coolTime += Time.deltaTime;
        if (coolTime >= cooldownTime)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                Attack();
                coolTime = 0f;
            }
        }


        
            
        
    }



    private void Attack()
    {
        Vector2 direction = GetMouseWorldPosition();
        float spawnRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, spawnRotation));
        bulletRB = spawnedBullet.GetComponent<Rigidbody2D>();

        bulletRB.velocity = direction.normalized * bullet.GetComponent<Bullet>().speed;



    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mouseWorldPos.x - transform.position.x, mouseWorldPos.y - transform.position.y);
        return dir;
    }
}
