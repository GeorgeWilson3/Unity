
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private Text scoreText;
    public static int score = 0;

    public int Score
    {
        set
        {
            score += value;
            scoreText.text = score.ToString();
        }
    }
    

    private void Start()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }

    public static void Reset()
    {
        score = 0;        
    }
}
