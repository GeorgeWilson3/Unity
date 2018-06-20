using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 150;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float projectileSpeed = 5f;
    [SerializeField]
    private float shotsPerSeccond = 0.5f;
    [SerializeField]
    private int scoreValue = 150;
    private ScoreKeeper scoreKeeper;
    [SerializeField]
    private AudioClip laserSound;
    [SerializeField]
    private AudioClip explosionSound;


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
                ScoreKeeper.Score = scoreValue;
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                Destroy(gameObject);
            }
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
