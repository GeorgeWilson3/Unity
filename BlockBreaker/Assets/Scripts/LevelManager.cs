using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		// Application.LoadLevel (name);
        SceneManager.LoadScene(name);
        Brick.breakableCount = 0;
        
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        // Application.LoadLevel(Application.loadedLevel + 1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        Brick.breakableCount = 0;
    }

    public void BricksDetroyed()
    {
        // if last bick is destroyed
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
