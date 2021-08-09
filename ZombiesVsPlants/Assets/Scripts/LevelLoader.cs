using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currSceneIdx;

    void Start() {
        currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        if (currSceneIdx == 2)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(currSceneIdx);
    }

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currSceneIdx + 1);
    }

    public void LoadYouLose() {
        SceneManager.LoadScene("LoseScreen");
    }

    public void LoadOptions() {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
