using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float acceleration = 6f;
    public float maxSpeed = 8f;
    public Vector2 direction;
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.left * maxSpeed * Time.deltaTime);
       // transform.position += (Vector3)direction * maxSpeed * Time.deltaTime;



        /*   direction = this.transform.position;
           velocity += acceleration * Time.deltaTime * direction;
           direction.Normalize();
           transform.position += (Vector3)velocity * Time.deltaTime;
           velocity = Vector2.ClampMagnitude(velocity, maxSpeed); */



    }
}
