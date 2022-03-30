using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {

    public float enemyHealth = 300f;
    public GameObject enemyLaserPrefab;
    private Vector3 offsetOfEnemeyLaser;
    scoreScript accessToScoreScript;
    public AudioClip enemyLaserSFX;
    public AudioClip dieSFX;


    void Start()
    {
        accessToScoreScript = GameObject.Find("scoreUI").GetComponent<scoreScript>();
    }


    void Update()
    {
        float probability = Time.deltaTime * 0.999f;
        if(Random.value < probability)
        {
            performEnemyFire();
        }
    }

    void performEnemyFire()
    {
        offsetOfEnemeyLaser = new Vector3(0f, -1f, 0f);
        GameObject enemyLaser = Instantiate(enemyLaserPrefab, transform.position + offsetOfEnemeyLaser, Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -10f);

        AudioSource.PlayClipAtPoint(enemyLaserSFX, transform.position);
    }




    void OnTriggerEnter2D(Collider2D collideWithTheEnemy)
    {
        laserPower accessToLaserPower = collideWithTheEnemy.gameObject.GetComponent<laserPower>();

        if (accessToLaserPower)
        {
            enemyHealth = enemyHealth - accessToLaserPower.performDamage();
            accessToLaserPower.Hit();
        }

        if(enemyHealth <= 0)
        {
            //destroy the enemy after health reaches 0.
            Destroy(gameObject);
            accessToScoreScript.ScoreAPoint();
            AudioSource.PlayClipAtPoint(dieSFX, transform.position);
        }
    }
}
