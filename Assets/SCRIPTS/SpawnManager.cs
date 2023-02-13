using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesInScene;
    private int enemiesPerWave = 1;
    public GameObject[] powerupPrefab;


    private void Start()
    {
        SpawnEnemyWave(enemiesPerWave); //instanciar un enemigo
        

    }

    private float spawnRange = 9f; //limite de la plataforma
    private Vector3 RandomSpawnPosition()
    {
        float randX = Random.Range(-spawnRange, spawnRange);
        float randZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randX, 0, randZ);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        int randomIndex = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[randomIndex], RandomSpawnPosition(), Quaternion.identity);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(),
            Quaternion.identity);
        }
    }

    private void Update()
    {
        //buscamos constantemente la cantidad de enemigos que hay en escena
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        if (enemiesInScene <= 0)
        {
            //si me quedo sin enemigos en escena, aumento en uno los enemigos por oleada
            enemiesPerWave++;
            //llamo a una nueva oleada
            SpawnEnemyWave(enemiesPerWave);
         
        }
    }

}
