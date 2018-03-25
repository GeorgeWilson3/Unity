using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance;

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
}
