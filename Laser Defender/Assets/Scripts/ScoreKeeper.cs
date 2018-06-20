
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private static Text scoreText;
    [SerializeField]
    private static int score;

    public static int Score
    {
        get { return score; }
        set
        {
            score += value;
            scoreText.text = Score.ToString();
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
