using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float acceleration = 6f;
    public float maxSpeed = 8f;
    public Vector2 direction;
    public Vector2 velocity;
    public GameManage gameManageRef;


    // Start is called before the first frame update
    void Start()
    {
        gameManageRef = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {

        maxSpeed = gameManageRef.GetLevelSpeed();
        transform.Translate(Vector3.left * maxSpeed * Time.deltaTime);
     
    }


}
