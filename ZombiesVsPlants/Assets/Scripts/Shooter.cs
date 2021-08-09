using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    GameObject projectileParent;
    AttackarSpawner myLaneSpawner;
    Animator animator;

    public void Fire() {
        GameObject newProjectile = Instantiate(
            projectile,
            gun.transform.position,
            transform.rotation
        ) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

    public void Start() {
        SetLaneSpawner();
        CreateProjectileParent();
        animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
