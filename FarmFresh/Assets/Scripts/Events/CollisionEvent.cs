using UnityEngine;
using UnityEngine.Events;


public class CollisionEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.CollisionEvent?.Invoke(new GameObjectCollisionData(this.gameObject, collision.gameObject));
    }
}

