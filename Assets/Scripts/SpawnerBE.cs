using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBE : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject Cactus2;
    public GameObject Cactus3;

    // Cooldown per ogni oggetto separato (ogni oggetto avrà il proprio timer)
    private float timeStampObjectToSpawn;
    private float timeStampCactus2;
    private float timeStampCactus3;

    // Minimo e massimo per i cooldown
    public float minCooldownObjectToSpawn = 5f;
    public float maxCooldownObjectToSpawn = 10f;
    public float minCooldownCactus2 = 7f;
    public float maxCooldownCactus2 = 12f;
    public float minCooldownCactus3 = 10f;
    public float maxCooldownCactus3 = 15f;

    // Tempo minimo che deve passare prima che un altro cactus possa essere spawnato
    private float minTimeBetweenCactusSpawn = 3f; // 3 secondi
    private float lastCactusSpawnTime = 0f; // Timestamp dell'ultimo spawn di un cactus

    // Start is called before the first frame update
    void Start()
    {
        // Impostiamo i timestamp per ciascun oggetto
        timeStampObjectToSpawn = Time.time;
        timeStampCactus2 = Time.time;
        timeStampCactus3 = Time.time;
    }

    // Funzione per ottenere un cooldown casuale
    float GetRandomCooldown(float minCooldown, float maxCooldown)
    {
        return Random.Range(minCooldown, maxCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        // Controlla se il cooldown di Cactus2 è scaduto e se è passato abbastanza tempo dall'ultimo spawn
        if (Time.time - timeStampCactus2 >= GetRandomCooldown(minCooldownCactus2, maxCooldownCactus2) &&
            Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
        {
            Instantiate(Cactus2, transform.position, transform.rotation); // Spawna Cactus2
            timeStampCactus2 = Time.time; // Resetta il timer per Cactus2
            lastCactusSpawnTime = Time.time; // Memorizza il tempo dell'ultimo spawn di un cactus
        }

        // Controlla se il cooldown di Cactus3 è scaduto e se è passato abbastanza tempo dall'ultimo spawn
        if (Time.time - timeStampCactus3 >= GetRandomCooldown(minCooldownCactus3, maxCooldownCactus3) &&
            Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
        {
            Instantiate(Cactus3, transform.position, transform.rotation); // Spawna Cactus3
            timeStampCactus3 = Time.time; // Resetta il timer per Cactus3
            lastCactusSpawnTime = Time.time; // Memorizza il tempo dell'ultimo spawn di un cactus
        }

        // Controlla se il cooldown per objectToSpawn è scaduto
        if (Time.time - timeStampObjectToSpawn >= GetRandomCooldown(minCooldownObjectToSpawn, maxCooldownObjectToSpawn))
        {
            // Randomizza quale oggetto spawnare
            int randomObject = Random.Range(0, 3);  // 0, 1, o 2

            if (randomObject == 0 && Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
            {
                Instantiate(Cactus2, transform.position, transform.rotation);
                lastCactusSpawnTime = Time.time; // Memorizza il tempo dell'ultimo spawn di un cactus
            }
            else if (randomObject == 1 && Time.time - lastCactusSpawnTime >= minTimeBetweenCactusSpawn)
            {
                Instantiate(Cactus3, transform.position, transform.rotation);
                lastCactusSpawnTime = Time.time; // Memorizza il tempo dell'ultimo spawn di un cactus
            }
            else if (randomObject == 2)
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation);
            }

            timeStampObjectToSpawn = Time.time; // Resetta il timer per objectToSpawn
        }
    }
}
