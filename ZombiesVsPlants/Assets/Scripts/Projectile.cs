using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float damageAmount = 100f;
    // [SerializeField] float spinSpeed = 30f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (attacker && health) {
            health.DealDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
