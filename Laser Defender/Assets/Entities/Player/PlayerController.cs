using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float padding = 0.5f;
    public GameObject Projectile;
    public float projectileSpeed = 2f;
    public float firingRate = 1.2f;
    public float health = 250f;
    public AudioClip laserSound;
    public AudioClip death;

    private float xMin;
    private float xMax;


    // Use this for initialization
    void Start ()
    {
        Debug.Log("New Player ");
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;

        ScoreKeeper.Reset();
    }
	
    void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);

        // GameObject laserBeam = Instantiate(Projectile, transform.position + offset, Quaternion.identity) as GameObject;
        GameObject laserBeam = Instantiate(Projectile, transform.position , Quaternion.identity) as GameObject;
        laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(laserSound, transform.position);

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.0000001f, firingRate);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
       

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            transform.position += Vector3.right * speed * Time.deltaTime;
        }


        // Restrict player to game space
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {        
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Debug.Log("Player collided with a missile.");

            health -= missile.GetDamage();
            missile.Hit();
            if (health < -0)
            {
                AudioSource.PlayClipAtPoint(death, transform.position);
                LevelManager manager =  GameObject.Find("LevelManager").GetComponent<LevelManager>();
                manager.LoadLevel("Win Screen");
                Destroy(gameObject);
            }

            // Debug.Log("Hit by a projectile");
        }
    }
}
