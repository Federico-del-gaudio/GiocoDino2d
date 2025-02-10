using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChromeDinoBE : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float maxSpeed;
    public float jumpVelocity;
    public float jumpHeight = 3f;
    public bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGround && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
            
    }

    private void Jump()
    {
      
            jumpVelocity = Mathf.Sqrt(2f * Physics2D.gravity.magnitude * rb.gravityScale * jumpHeight);   //magnitute (quanto è lungo il vettore)
            rb.velocity = Vector2.up * maxSpeed * jumpVelocity;
            isGround = false;

        
    }
}
