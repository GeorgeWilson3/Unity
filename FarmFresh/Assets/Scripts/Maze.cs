using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public GameObject Background;
    //private List<Food> foodPellets;
    private List<GameObject> foodPellets;
    public Food foodPrefab;
    private int totalPoints;

    private readonly int screenWidth = 7;
    private readonly int screenHeight = 5;

    private void Awake()
    {
        GameEvents.foodPicked.AddListener(FoodPickedUp);
        GameEvents.scorePoints.AddListener(OnPoints);
    }

    private void FoodPickedUp(FoodPickedData foodPickedData)
    {
        Debug.Log("Removing a food.");
        foodPellets.Remove(foodPickedData.food);
    }

    // Start is called before the first frame update
    void Start()
    {    
        Debug.Log("Load maze");
        foodPellets = new List<GameObject>();
        LoadMaze();
        totalPoints = 0;        
    }

    private void OnPoints(ScorePointsData scorePoints)
    {
        totalPoints += scorePoints.points;
        Debug.Log($"Current score is: {totalPoints}");
    }

    // Update is called once per frame
    void Update()
    {
        if (foodPellets.Count == 0)
        {
            Debug.Log("Good job!");
            GameEvents.sceneOver?.Invoke();
        }
        else
        {
            GameEvents.sceneRunning?.Invoke();
        }
    }

    private void LoadMaze()
    {
        for (int screenX = -screenWidth; screenX < screenWidth; screenX++)
        {
            for (int screenY = -screenHeight; screenY < screenHeight; screenY++)
            {
                float posX = screenX;
                float posY = screenY;

                // Adding .f to center the food in the tile
                Vector3 position = new Vector3(posX + .5f, posY + .5f);
               
                Food newFood = Instantiate(foodPrefab, position, Quaternion.identity);
                foodPellets.Add(newFood.gameObject);
            }
        }       
    }


    public void OnDestroy()
    {
        GameEvents.sceneOver?.Invoke();
    }
}
