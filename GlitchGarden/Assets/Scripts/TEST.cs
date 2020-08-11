using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefsManager.GetMasterVolume());
        PlayerPrefsManager.SetMasterVolumme(0.3f);
        print(PlayerPrefsManager.GetMasterVolume());

        print(PlayerPrefsManager.IsLevelUnlocked(2));
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(2));


        print(PlayerPrefsManager.GetDifficulty());
        PlayerPrefsManager.SetDifficulty(10.2f);
        print(PlayerPrefsManager.GetDifficulty());

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
