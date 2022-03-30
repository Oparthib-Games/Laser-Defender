using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    private bool movingRight = true;
    public float speedOfEnemy;
    public float width, height;
    private float xmin, xmax;

    void Start()
    {
        SpawnUntilFull();

        float offsetOfCamera = this.transform.position.z - Camera.main.transform.position.z;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, offsetOfCamera));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0, offsetOfCamera));

        xmin = leftMost.x;
        xmax = rightMost.x;
    }

    /*void instantiateFromChildOfTheChild()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            GameObject enemyAsGameobject = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

            //////enemyAsGameobject.transform.parent = transform;
            enemyAsGameobject.transform.parent = child;
        }
    }*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(width, height));
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speedOfEnemy * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speedOfEnemy * Time.deltaTime;
        }

        float leftEdgeOfFormation = this.transform.position.x - (0.5f * width);
        float rightEdgeOfFormation = this.transform.position.x + (0.5f * width);

        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        }
        else if(rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }

        if (AllMembersDead())
        {
            Debug.Log("Empty Formation");
            SpawnUntilFull();
        }
    }

    void SpawnUntilFull()
    {
        //Transform freePosition = NextFreePosition();
        if(NextFreePosition())
        {
            GameObject enemyAsGameobject = Instantiate(enemyPrefab, NextFreePosition().transform.position, Quaternion.identity) as GameObject;
            enemyAsGameobject.transform.parent = NextFreePosition();
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", 0.5f);
        }
    }

    Transform NextFreePosition()
    {
        foreach (Transform PositionEmptyGameObject in transform)
        {
            if (PositionEmptyGameObject.childCount == 0)
            {
                return PositionEmptyGameObject;
            }
        }
        return null;
    }

    bool AllMembersDead()
      {
          foreach(Transform PositionEmptyGameObject in transform)
          {
              if (PositionEmptyGameObject.childCount > 0)
              {
                  return false;
              }
          }
          return true;
    }


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*bool AllMembersDead()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }*/
}
