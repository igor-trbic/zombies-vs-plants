using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "Master volume";
    const string DIFFICULTY_KEY = "Difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 3f;

    public static void SetMasterVolume(float volume) {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("MASTER VOLUME OUT OF RANGE");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficultyLvl) {
        if(difficultyLvl >= MIN_DIFFICULTY && difficultyLvl <= MAX_DIFFICULTY) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficultyLvl);
        } else {
            Debug.LogError("DIFFICULTY OUT OF RANGE");
        }
    }
    
    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
