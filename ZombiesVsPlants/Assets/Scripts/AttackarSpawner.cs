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
        } while (spawn);
    }

    private void SpawnAttacker() {
        Attacker attacker = Instantiate(
            attackerPrefab,
            transform.position,
            transform.rotation
        ) as Attacker;
        // parent is this transform so it's placed as child
        attacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
