using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
        Brick.BreakableCount = 0;
        
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        Brick.BreakableCount = 0;
    }

    public void BricksDetroyed()
    {
        // if last bick is destroyed
        if (Brick.BreakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
