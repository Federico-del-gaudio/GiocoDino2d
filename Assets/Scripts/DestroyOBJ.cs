using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOBJ : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       GameObject collidedObject = collision.gameObject;

        Destroy(collidedObject);
    }

}
