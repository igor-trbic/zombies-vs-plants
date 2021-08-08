using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 4;
    int currSceneIdx;
    // Start is called before the first frame update
    void Start()
    {
        currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        if (currSceneIdx == 0) {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currSceneIdx+1);
    }

    public void LoadYouLose() {
        SceneManager.LoadScene("LoseScreen");
    }
}
