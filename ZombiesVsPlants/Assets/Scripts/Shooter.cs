using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    public void Fire() {
        Instantiate(
            projectile,
            gun.transform.position,
            transform.rotation
        );
    }
}
