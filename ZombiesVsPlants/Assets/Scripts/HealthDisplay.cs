using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField] float baseHealth = 6f;

    float playerHealth;
    Text playerHealthText;

    void Start()
    {
        playerHealth = baseHealth / PlayerPrefsController.GetDifficulty();
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
                FindObjectOfType<LevelController>().HandleLoseCondition();
            }
        }
    }
}
