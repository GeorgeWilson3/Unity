using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    void OnEnable()
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[levelMusicChangeArray.Rank];
        Debug.Log("Playing clip: " + thisLevelMusic);

        // If there is music to play then let's play it
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    //private void OnLevelWasLoaded(int level)
    //{
    //    AudioClip thisLevelMusic = levelMusicChangeArray[level];
    //    Debug.Log("Playing clip: " + thisLevelMusic);
    //    //Debug.Log();

    //    // If there is music to play then let's play it
    //    if (thisLevelMusic)
    //    {
    //        audioSource.clip = thisLevelMusic;
    //        audioSource.loop = true;
    //        audioSource.Play();
    //    }
    //}
}
