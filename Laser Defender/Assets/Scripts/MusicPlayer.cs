using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance;
    [SerializeField]
    private AudioClip startClip;
    [SerializeField]
    private AudioClip gameClip;
    [SerializeField]
    private AudioClip endClip;

    private AudioSource music;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            OnLevelWasLoaded(0);

        }
		
	}

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer loaded level " + level);
        music.Stop();

        if (level == 0)
        {
            music.clip = startClip;
        }
        else if (level == 1)
        {
            music.clip = gameClip;
        }
        else if (level == 2)
        {
            music.clip = endClip;
        }
        {
            // Add more here if we add any new levels.
        }

        music.loop = true;
        music.Play();
        

    }
}
