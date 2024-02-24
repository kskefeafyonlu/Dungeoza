using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Transform targetTransform; 
    private Rigidbody2D rb; // this objects rigidbody
    
    private Vector2 targetDirection;


    private void Awake() 
    {
        targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate() 
    {
        Vector2 transformDiff = targetTransform.position - transform.position;
        rb.AddForce(transformDiff.normalized * movementSpeed);
    }
}
