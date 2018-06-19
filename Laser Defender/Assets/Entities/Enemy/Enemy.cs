using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float health = 150;
    public GameObject projectile;
    public float projectileSpeed = 5f;
    public float shotsPerSeccond = 0.5f;
    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;
    public AudioClip laserSound;
    public AudioClip explosionSound;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {      
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <- 0)
            {
                scoreKeeper.Score = scoreValue;
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                Destroy(gameObject);
            }
            
            // Debug.Log("Hit by a projectile");
        }
    }

    void Fire()
    {
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSound, transform.position);
    }

    public void Update()
    {
        float probability = Time.deltaTime * shotsPerSeccond;
        if (UnityEngine.Random.value < probability)
        {
            Fire();
        }
    }

}
