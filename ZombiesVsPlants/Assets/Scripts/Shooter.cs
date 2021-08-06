using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackarSpawner myLaneSpawner;
    Animator animator;

    public void Fire() {
        Instantiate(
            projectile,
            gun.transform.position,
            transform.rotation
        );
    }

    public void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    public void Update() {
        if(isAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackarSpawner[] spawners = FindObjectsOfType<AttackarSpawner>();

        foreach (AttackarSpawner spawner in spawners) {
            bool isCloseEnough = (
                Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon
            );
            if (isCloseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool isAttackerInLane() {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }
        return true;
    }
}
