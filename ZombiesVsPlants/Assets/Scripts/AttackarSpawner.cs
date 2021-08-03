using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackarSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    bool spawn = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do {
            var randomSec = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomSec);
            SpawnAttacker();
            // yield return StartCoroutine(SpawnEnemies());
        } while (spawn);
    }

    private void SpawnAttacker() {
        Instantiate(
            attackerPrefab,
            transform.position,
            transform.rotation
        );
    }

    private IEnumerator SpawnEnemies() {
        var randomSec = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(randomSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
