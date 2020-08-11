using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float followRange = 3f;
    private Vector3 playerLocation;

    private int randomCycle = 0;
    private int randomX = 0;
    private int randomY = 0;
    private float maxRandom = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = new Vector3(0, 0);
        GameEvents.playerLocation.AddListener(UpdatePlayerPosition);
    }

    private void UpdatePlayerPosition(Vector3 playerLocationData)
    {
        playerLocation = playerLocationData;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(playerLocation, gameObject.transform.position);

        if (distance < followRange)
        {
            // We are in range to notice the other object so we can follow.            
            FollowMode();
        }
        else
        {
            RanmdomMode();
        }
    }

    private void FollowMode()
    {
        //assign movement to a single vector3
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerLocation, (moveSpeed - 1) * Time.deltaTime);

        Debug.Log("In range!");
    }


    private void RanmdomMode()
    {
        if(randomCycle == 0)
        {
            randomCycle = (int) UnityEngine.Random.Range(1f, maxRandom);
            randomX = UnityEngine.Random.Range(-1, 2);
            randomY = UnityEngine.Random.Range(-1, 2);
        }
        else
        {
            randomCycle--;
        }

        float horizontalMovement = randomX * moveSpeed * Time.deltaTime;
        float verticalMovement = randomY * moveSpeed * Time.deltaTime;

        //assign movement to a single vector3
        Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);
        MoveEnemy(directionOfMovement);
        //gameObject.transform.Translate(directionOfMovement);

        Debug.Log("Random mode!");
    }

    private void MoveEnemy(Vector3 newPosition)
    {
        gameObject.transform.Translate(newPosition);
    }

}
