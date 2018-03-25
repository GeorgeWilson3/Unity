using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted;
    private AudioSource boing;

    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();

        paddleToBallVector = this.transform.position - paddle.transform.position;
        boing = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            // Lock the ball to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                // Launch the ball
                hasStarted = true;
                print("mouse clicked, so now we will launch the ball.");
                Rigidbody2D body = GetComponent<Rigidbody2D>();
                body.velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f ));
        print(tweak);

        if (hasStarted)
        {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.velocity += tweak;


            if (collision.gameObject.tag != "Breakable")            
            {
                boing.Play();
            }
            
        }
    }
}
