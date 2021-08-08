using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.6f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1f;

    void Start() {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update() {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        } else {
            Debug.LogWarning("No Music player, did you start from splash screen?");
        }
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
