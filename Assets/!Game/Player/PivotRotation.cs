using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 mousePosition;
    float rotationDegrees;
    

    
    void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;

        rotationDegrees = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationDegrees);
        Debug.Log(rotationDegrees);
    }
}
