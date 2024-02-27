using System.Collections;
using TMPro;
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
        public int waveLevel;

        public void UpdateEnemyList()
        {
            foreach (GameObject enemyObject in enemyList)
            {
                
                EnemyLevel levelScript = enemyObject.GetComponent<EnemyLevel>();
                levelScript.level = waveLevel;
                // levelScript.UpdateEnemyAttributes();
                Debug.Log(levelScript.level);
            }
        }
    }

    ///////////////////////

    public Wave[] waveList;
    private int currentWaveIndex = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;
    int waveCountDownInt;
    private TextMeshProUGUI waveSecondsText;


    public Transform[] spawnPositions;

    private TextMeshProUGUI enemiesLeftText;
    int enemiesLeft;
    float checkCooldown;

    




    private void Start() 
    {
        waveCountDown = timeBetweenWaves;
        enemiesLeftText = GameObject.Find("EnemiesLeftText").GetComponent<TextMeshProUGUI>();
        waveSecondsText = GameObject.Find("WaveSecondsText").GetComponent<TextMeshProUGUI>();
    }


    private void Update() 
    {
        waveCountDown-= Time.deltaTime;

        if (waveList[currentWaveIndex].state == WaveState.OnHold && checkCooldown >= 0.5f)
        {
            //check if any enemies alive
            if(!CheckForAliveEnemies())
            {
                //next wave
                if(waveList.Length > currentWaveIndex+1)
                {
                    waveList[currentWaveIndex].state = WaveState.Finished;
                    enemiesLeftText.gameObject.SetActive(false);
                    currentWaveIndex += 1;
                    waveCountDown = timeBetweenWaves;
                }
                else{
                    Debug.Log("Reached the end of waveslist");
                }
            }
            else{
                return;
            }

        }
        checkCooldown += Time.deltaTime;
        

        if (waveCountDown <= 0)
        {
            waveSecondsText.gameObject.SetActive(false);

            if(waveList[currentWaveIndex].state == WaveState.NotStarted)
            {
                StartCoroutine(StartWave(waveList[currentWaveIndex]));
            }
            
        }
        else
        {
            waveSecondsText.gameObject.SetActive(true);
            waveCountDownInt = (int) (waveCountDown + 0.99f) ;
            waveSecondsText.text = $"Wave Coming In: {waveCountDownInt}";
        }
    }






    IEnumerator StartWave(Wave wave)
    {
        wave.UpdateEnemyList();
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