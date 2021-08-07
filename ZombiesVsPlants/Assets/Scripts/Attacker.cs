using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 5f)]
    float currSpeed = 0.6f;
    GameObject currTarget;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currSpeed);
        UpdateAnimationState();
    }

    public void SetMovementSpeed(float speed) {
        currSpeed = speed;
    }

    public void Attack(GameObject target) {
        animator.SetBool("isAttacking", true);
        currTarget = target;
    }

    public void StrikeCurrTarget(float damage) {
        if (!currTarget) {
            return;
        }
        Health health = currTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }
    }

    private void UpdateAnimationState() {
        if (!currTarget) {
            animator.SetBool("isAttacking", false);
        }
    }
}
