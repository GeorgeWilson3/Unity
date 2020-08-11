
using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.CollisionEvent.AddListener(PlayerCollision);
    }

    private void PlayerCollision(GameObjectCollisionData data)
    {
        if(data.collided == this.gameObject)
        {
            if(data.collider.tag == "Player")
            {
                GameEvents.playerDeath?.Invoke();
            }
        }
    }
}
