using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField] int playerHealth = 5;
    Text playerHealthText;

    void Start()
    {
        playerHealthText = GetComponent<Text>();
        UpdateHealth();
    }

    private void UpdateHealth () {
        playerHealthText.text = playerHealth.ToString();
    }

    public void InflictDamage(int healthAmount) {
        if (playerHealth >= healthAmount) {
            playerHealth -= healthAmount;
            UpdateHealth();
            if (playerHealth <= 0) {
                FindObjectOfType<LevelLoader>().LoadYouLose();
            }
        }
    }
}
