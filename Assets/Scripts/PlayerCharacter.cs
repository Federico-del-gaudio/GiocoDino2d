using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Maximum movement speed
    public float maxSpeed;
    public Vector2 direction;

    void Start()
    {
    }

    void Update()
    {
        // Get the input axes for movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Normalize the direction to avoid faster diagonal movement
        direction = new Vector2(x, y).normalized;

        Debug.Log(direction);

        // Move the character using maxSpeed and the direction
        transform.position += (Vector3)direction * maxSpeed * Time.deltaTime;
    }
}
