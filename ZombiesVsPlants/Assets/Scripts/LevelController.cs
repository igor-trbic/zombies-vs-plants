using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad;
    [SerializeField] GameObject loseLabel;

    int numOfAttackers = 0;
    bool levelTimerFinished = false;

    void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawn() {
        numOfAttackers++;
    }

    public void AttackerKilled() {
        numOfAttackers--;
        if (numOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackarSpawner[] spawners = FindObjectsOfType<AttackarSpawner>();
        foreach (AttackarSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public void HandleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

}
