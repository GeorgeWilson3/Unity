
using System;
using UnityEngine;


public class Food : MonoBehaviour
{
    public int points = 100;
    public float freshTimer = 999;

    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    public SpriteRenderer sprite;

    private bool sceneRunning = false;
    


    public void Start()
    {
        GameEvents.CollisionEvent.AddListener(SomethingCollided);
        freshTimer = 60;
        GameEvents.countdownTimer?.Invoke(freshTimer);

        GameEvents.sceneRunning.AddListener(SceneRunning);
     
    }

    private void SceneRunning()
    {
        sceneRunning = true;
    }

    private void SomethingCollided(GameObjectCollisionData data)
    {        
        if (data.collided == this.gameObject)
        {
            if (data.collider.tag == "Player" && sceneRunning)
            {
                Debug.Log("Hit the food!");
                GameEvents.scorePoints?.Invoke(new ScorePointsData(points));
            }
            
            GameEvents.foodPicked?.Invoke(new FoodPickedData(this.gameObject, data.collider));
            Destroy(data.collided);
        }
    }
}
