using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate music player.");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
