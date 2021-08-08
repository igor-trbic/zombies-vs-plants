using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Attacker>() != null) {
            Attacker attacker = otherObject.GetComponent<Attacker>();
            FindObjectOfType<HealthDisplay>().InflictDamage(attacker.GetDamageToPlayer());
        }
    }
}
