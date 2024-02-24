using UnityEngine;


public class SpawnHandler : MonoBehaviour
{
    
}

public class Wave : ScriptableObject
{
    [SerializeField] private WaveState state;
    [SerializeField] private GameObject[] spawnList;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnInterval;



}

public enum WaveState
{
    Standby,
    Spawning,
    Ended,
    Cooldown
}