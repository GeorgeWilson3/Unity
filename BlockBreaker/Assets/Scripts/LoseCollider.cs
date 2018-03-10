using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void OnCollisionEnter2D(Collision2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        // print("Collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose Screen");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
