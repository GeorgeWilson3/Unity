
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = ScoreKeeper.Score.ToString();
        ScoreKeeper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
