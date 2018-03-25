using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    public void OnCollisionEnter2D(Collision2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
}
