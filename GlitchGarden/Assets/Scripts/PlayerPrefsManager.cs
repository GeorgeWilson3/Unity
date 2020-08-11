using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_"; // This will kbe procedded by a number


    public static int SceneManagerScene { get; private set; }

    #region Volume

    public static void SetMasterVolumme(float volume)
    {
        if (volume > 0f && volume < 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range.");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME);
    }

    public static void UnlockLevel(int level)
    {
        if(level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);//  use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not iun build order.");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        bool found = false;
        
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            if (levelValue == 1)
            {
                found = true;
            }
        }
        else
        {
            Debug.LogError("Trying to unlock level not iun build order.");
        }

        return found;
    }

    #endregion

    #region Difficulty

    public static void SetDifficulty (float difficulty)
    {
        if (difficulty > 0f && difficulty < 1f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }


    #endregion

}
