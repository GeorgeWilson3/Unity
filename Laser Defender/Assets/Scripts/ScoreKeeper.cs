
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{


    private static Text scoreText;
    [SerializeField]
    private int score;

    public static Text ScoreText
    {
        get { return scoreText; }
        set { scoreText = value; }

    }

    public int Score
    {
        get { return score; }
        set
        {
            score += value;            
        }
    }

    private void Start()
    {
        Enemy.OnScore += Enemy_OnScore;

        scoreText = GetComponent<Text>();
        Reset();
    }

    private void Enemy_OnScore(int points)
    {
        Score = points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = Score.ToString();
    }

    public void Reset()
    {
        score = 0;
        UpdateScoreText();
    }
}
