using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    // Food
    public static FoodPicked foodPicked = new FoodPicked();
    public static ScorePoints scorePoints = new ScorePoints();
    public static UnityEvent sceneOver = new UnityEvent();
    public static UnityEvent sceneRunning = new UnityEvent();

    public static CountdownTimer countdownTimer = new CountdownTimer();

    // Player
    public static GameObjectCollision CollisionEvent = new GameObjectCollision();
    public static UnityEvent playerDeath = new UnityEvent();
    public static PlayerLocation playerLocation = new PlayerLocation();


}

#region Food Events

public class FoodPicked : UnityEvent<FoodPickedData> { }
public class ScorePoints : UnityEvent<ScorePointsData> { }
public class CountdownTimer : UnityEvent<float> { }

public class FoodPickedData
{
    public GameObject food;
    public GameObject picker;

    public FoodPickedData(GameObject food, GameObject picker)
    {
        this.food = food;
        this.picker = picker;
    }
}

public class ScorePointsData
{
    public int points;
    public ScorePointsData(int points)
    {
        this.points = points;
    }
}

#endregion


#region Player Events

public class GameObjectCollision : UnityEvent<GameObjectCollisionData> { }
public class PlayerLocation : UnityEvent<Vector3> { }


public class GameObjectCollisionData
{
    public GameObject collider;
    public GameObject collided;
    //public int points;

    public GameObjectCollisionData(GameObject collider, GameObject collided)
    {
        this.collider = collider;
        this.collided = collided;
        //this.points = points;
    }

}

#endregion