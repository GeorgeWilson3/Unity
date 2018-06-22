
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    // Use this for initialization
    private void Start ()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = ScoreKeeper.scoreText.text; //  scoreKeeper.Score.ToString();
	}	
}
