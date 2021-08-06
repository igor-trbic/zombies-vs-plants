using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown() {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y
        );
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPos) {
        Defender newDefender = Instantiate(
            defender,
            spawnPos,
            Quaternion.identity
        ) as Defender;
    }

    private void AttemptToPlaceDefender(Vector2 pos) {
        var BreadDisplay = FindObjectOfType<BreadDisplay>();
        int defenderCost = defender.GetBreadCost();

        if (BreadDisplay.HaveEnoughBread(defenderCost)) {
            SpawnDefender(pos);
            BreadDisplay.SpendBread(defenderCost);
        }
    }

    public void SetSelectedDefender(Defender selectedDefender) {
        defender = selectedDefender;
    }
}
