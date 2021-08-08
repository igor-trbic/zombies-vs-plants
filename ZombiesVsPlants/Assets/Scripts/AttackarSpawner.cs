using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackarSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackersPrefab;

    bool spawn = true;
    IEnumerator Start()
    {
        do {
            var randomSec = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomSec);
            SpawnAttacker();
        } while (spawn);
    }

    private void SpawnAttacker() {
        int rndIdx = Mathf.RoundToInt(
            Random.Range(0, attackersPrefab.Length)
        );
        Spawn(attackersPrefab[rndIdx]);
    }

    private void Spawn(Attacker rndAttacker) {
        Attacker attacker = Instantiate(
            rndAttacker,
            transform.position,
            transform.rotation
        ) as Attacker;
        // parent is this transform so it's placed as child
        attacker.transform.parent = transform;
    }

    public void StopSpawning() {
        spawn = false;
    }
}
