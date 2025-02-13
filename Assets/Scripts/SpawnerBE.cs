using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBE : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject Cactus2;
    public GameObject Cactus3;

    private float timeStampObjectToSpawn;
    private float timeStampCactus2;
    private float timeStampCactus3;

    public float minCooldownObjectToSpawn = 5f;
    public float maxCooldownObjectToSpawn = 10f;
    public float minCooldownCactus2 = 7f;
    public float maxCooldownCactus2 = 12f;
    public float minCooldownCactus3 = 10f;
    public float maxCooldownCactus3 = 15f;

    private float minTimeBetweenCactusSpawn = 8f;
    private float lastCactusSpawnTime = 0f;

    public float speedIncreaseInterval = 30f; // Tempo tra un incremento di velocità e l'altro
    public float speedIncreaseAmount = 2f; // Di quanto aumentare la velocità ogni 30s
    private float currentMaxSpeed = 5f; // Velocità iniziale dei nemici
    private float speedIncreaseTimestamp;

    void Start()
    {
        timeStampObjectToSpawn = Time.time;
        timeStampCactus2 = Time.time;
        timeStampCactus3 = Time.time;
        speedIncreaseTimestamp = Time.time;
    }

    float GetRandomCooldown(float minCooldown, float maxCooldown)
    {
        return Random.Range(minCooldown, maxCooldown);
    }

    void Update()
    {
        // Speed 
        if (Time.time - speedIncreaseTimestamp >= speedIncreaseInterval)
        {
            currentMaxSpeed += speedIncreaseAmount;
            speedIncreaseTimestamp = Time.time;
            currentMaxSpeed = Mathf.Min(currentMaxSpeed, 15f);
        }

        // Cactus2  cooldown 
        if (Time.time - timeStampCactus2 >= GetRandomCooldown(minCooldownCactus2, maxCooldownCactus2) &&
            Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
        {
            SpawnEnemy(Cactus2);
            timeStampCactus2 = Time.time;
        }

        // Cactus3  cooldown
        if (Time.time - timeStampCactus3 >= GetRandomCooldown(minCooldownCactus3, maxCooldownCactus3) &&
            Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
        {
            SpawnEnemy(Cactus3);
            timeStampCactus3 = Time.time;
        }

        // Random gameobject
        if (Time.time - timeStampObjectToSpawn >= GetRandomCooldown(minCooldownObjectToSpawn, maxCooldownObjectToSpawn))
        {
            int randomObject = Random.Range(0, 3);

            if (randomObject == 0 && Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
            {
                SpawnEnemy(Cactus2);
            }
            else if (randomObject == 1 && Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
            {
                SpawnEnemy(Cactus3);
            }
            else if (randomObject == 2)
            {
                SpawnEnemy(objectToSpawn);
            }

            timeStampObjectToSpawn = Time.time;
        }
    }

    // 
    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();

        if (enemyScript != null)    //Controllo script enemy
        {
            enemyScript.maxSpeed = currentMaxSpeed; //velocità attuale
        }

        lastCactusSpawnTime = Time.time;
    }

    void PickCooldown()
    {
      /*  float dieRoll = Random.Range(0f, 1f);
        float probabilityTreshold = 0f;

        PhaseData phase = Phases[index]

        for (int = 0; i < phase.probabilities.Lenght; i++) 
        {
          if( phase.probabilities[i] <= dieRoll){)
          cooldown = baseCooldown * phase.multipliers[i];
          break;
        }else
      { probabilityThreshold += phase.probabiities[i];
     
       }
       
        int intDieRoll = Random.Range(0,phase.obstacles.Lenght);
        probabilityThreshold = 0; 
            for (int = 0; i < phase.obstacle.Lenght; i++) 
        {
          if(intDieRoll <= probabilityThreshold){
            objectToSpawn = phase.obstacle[i]
            break;
}
        
    */
        }
}
