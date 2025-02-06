using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float acceleration = 6f;
    public float maxSpeed = 8f;
    public Vector2 direction;
    public Vector2 velocity;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - this.transform.position;
        velocity += acceleration * Time.deltaTime * direction;
        direction.Normalize();
        transform.position += (Vector3)velocity * Time.deltaTime;
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        


    }
}
