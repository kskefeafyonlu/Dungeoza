using System.Collections;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;


public class SpawnHandler : MonoBehaviour
{
    public enum WaveState
    {
        NotStarted,
        Spawning,
        OnHold,
        Finished
    }

    [System.Serializable]
    public class Wave
    {
        public WaveState state = WaveState.NotStarted;
        public string waveName;
        public GameObject[] enemyList;
        public int enemyAmount;
        public float spawnRate;
    }

    ///////////////////////

    public Wave[] waveList;
    private int currentWaveIndex = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public Transform[] spawnPositions;

    private TextMeshProUGUI enemiesLeftText;
    int enemiesLeft;




    private void Start() 
    {
        waveCountDown = timeBetweenWaves;
        enemiesLeftText = GameObject.Find("EnemiesLeftText").GetComponent<TextMeshProUGUI>();
    }


    private void Update() 
    {
        waveCountDown-= Time.deltaTime;

        if (waveList[currentWaveIndex].state == WaveState.OnHold)
        {
            //check if any enemies alive
            if(!CheckForAliveEnemies())
            {
                //next wave
                if(waveList.Length > currentWaveIndex+1)
                {
                    waveList[currentWaveIndex].state = WaveState.Finished;
                    currentWaveIndex += 1;
                    waveCountDown = timeBetweenWaves;
                    
                }
                else
                {
                    Debug.Log("Reached the end of waveslist");
                }

            }
            else
            {
                return;
            }
        }
        

        if (waveCountDown <= 0)
        {
            if(waveList[currentWaveIndex].state == WaveState.NotStarted)
            {
                StartCoroutine(StartWave(waveList[currentWaveIndex]));
            }
            
        }
    }






    IEnumerator StartWave(Wave wave)
    {
        wave.state = WaveState.Spawning;
        enemiesLeftText.gameObject.SetActive(false);

        //Spawn
        for (int i = 0; i < wave.enemyAmount; i++)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(wave.spawnRate);
        }


        wave.state = WaveState.OnHold;


        //WaitForKills

        yield break;
    }





    private float searchCountdown = 1f;

    private bool CheckForAliveEnemies()
    {
        enemiesLeftText.gameObject.SetActive(true);
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesLeftText.text = $"Enemies Left: {enemiesLeft}";


        searchCountdown -= Time.deltaTime;
        
        if(searchCountdown <= 0f)
        {
            if (enemiesLeft == 0)
            {
                searchCountdown = 1f;
                return false;
            }
            searchCountdown = 1f;
        }
        return true;
    }





    private void SpawnRandomEnemy()
    {
        int randomEnemyIndex = waveList[currentWaveIndex].enemyList.Length;
        Instantiate(waveList[currentWaveIndex].enemyList[UnityEngine.Random.Range(0, randomEnemyIndex)], spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)]);
        Debug.Log("Spawning Random Enemy");
    }
}