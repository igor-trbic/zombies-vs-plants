using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    private void Start() {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost() {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogError(name + " has no COST TEXT!");
        } else {
            costText.text = defenderPrefab.GetBreadCost().ToString();
        }
    }
}
