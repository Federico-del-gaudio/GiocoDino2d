using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerBE : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float cooldown = 1f;
    private int index; 
    public Phases[] phases;
    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Phases phase = phases[index];

      

        if ( Time.time >= phase.timeThreshold && index < phases.Length -1)
        {
            index++;
          
            phase = phases[index];
        }


        if (Time.time - timeStamp >= cooldown)
        { 
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            timeStamp = Time.time;
            cooldown = Random.Range(phase.minRange, phase.maxRange);

        }
    }
}
