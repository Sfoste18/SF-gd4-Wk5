using JetBrains.Annotations;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PowerupReflectPrefab;

public GameObject enemyPrefab;
    [SerializeField] float spawnRange;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        //float spawnPosX = Random.Range(spawnRange, -spawnRange);
        //float spawnPosZ = Random.Range(spawnRange, -spawnRange);
        //Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        //Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);

        //SpawnEnemyWave(3);
        SpawnEnemyWave(waveNumber);

        Instantiate(PowerupReflectPrefab, GenerateSpawnPosition(),PowerupReflectPrefab.transform.rotation);


    }
    public int waveNumber = 1;

    void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRange, -spawnRange);
        float spawnPosZ = Random.Range(spawnRange, -spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(enemyPrefab, transform.position + new Vector3(0, 0, 1), Quaternion.Euler(0, Random.Range(0, 360), 0));
            //Instantiate(enemyPrefab, transform.position + new Vector3(), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }

        if (enemyCount == 0) {Instantiate(PowerupReflectPrefab, GenerateSpawnPosition(), PowerupReflectPrefab.transform.rotation); }

        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) { waveNumber++; SpawnEnemyWave(waveNumber); }

    }
    public int enemyCount;
}
