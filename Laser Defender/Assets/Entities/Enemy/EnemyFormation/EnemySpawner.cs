using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float spawnDelay = 0.5f;
    public float speed = 0.05f;

    private float xMin;
    private float xMax;
    private int direction = 1;

    // Use this for initialization
    void Start ()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;        

        Vector3 leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

        xMin = leftBoundry.x; 
        xMax = rightBoundry.x;
        SpawnEnemiesUntilFull();
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private void SpawnEnemiesUntilFull()
    {
        Transform freePosition = NextFreePosition();

        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnEnemiesUntilFull", spawnDelay);
        }
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));

    }
    // Update is called once per frame
    void Update ()
    {
        transform.position += Vector3.left * speed * Time.deltaTime * direction;       

        // Restrict player to game space
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        if (transform.position.x - (0.5f * width) <= xMin )
        {
            direction = - 1;
        }
        else if (transform.position.x + (0.5f * width) >= xMax)
        {
            direction = 1;
        }

        if(AllMembersDead())
        {
            Debug.Log("Empty formation.");
            SpawnEnemiesUntilFull();
        }
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }
}
