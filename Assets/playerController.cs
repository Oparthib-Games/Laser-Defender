using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    private float xmin, xmax;
    private float awayFromCameraEdges = 1;
    public GameObject laserPrefab;
    public float firingRate = 0.5f;
    public float playerHealth = 100f;

    AudioSource playerLaserSFX;

	void Start () {

        playerLaserSFX = GetComponent<AudioSource>();
        playerLaserSFX.Stop();

        float offset = this.transform.position.z - Camera.main.transform.position.z;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, offset));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0, offset));

        xmin = leftMost.x + awayFromCameraEdges;
        xmax = rightMost.x - awayFromCameraEdges;
    }
	
	void Update () {

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float restrictionOfX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(restrictionOfX, transform.position.y, transform.position.z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("FireLaser", 0.00000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FireLaser");
        }
    }
    
    void FireLaser()
    {
        Vector3 offsetOfPlayerLaser = new Vector3(0f, 0.5f , 0f);
        GameObject laserAsGameObject = Instantiate(laserPrefab, transform.position + offsetOfPlayerLaser, Quaternion.identity) as GameObject;
        laserAsGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);

        playerLaserSFX.Play();
    }

    private void OnTriggerEnter2D(Collider2D collisionWithEnemyLaser)
    {
        laserPower accessToLaserPower = collisionWithEnemyLaser.gameObject.GetComponent<laserPower>();

        if (accessToLaserPower)
        {
            playerHealth -= accessToLaserPower.performDamage();
            accessToLaserPower.Hit();
        }
        if(playerHealth < 0)
        {
            Destroy(gameObject);

            levelManager accessToManagerOfLevels = GameObject.Find("managerOfLevels").GetComponent<levelManager>();
            accessToManagerOfLevels.startGame("scoreDesplayScene");
        }
    }
}
