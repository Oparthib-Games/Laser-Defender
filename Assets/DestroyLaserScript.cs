using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaserScript : MonoBehaviour {


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(28f, 2.5f));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
