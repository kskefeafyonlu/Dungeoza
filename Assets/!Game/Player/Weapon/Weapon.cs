using UnityEngine;

public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab;
    private float damage;
}
