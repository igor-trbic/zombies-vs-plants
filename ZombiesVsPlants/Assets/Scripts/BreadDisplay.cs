using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreadDisplay : MonoBehaviour
{

    [SerializeField] int breads = 200;
    Text breadText;

    void Start()
    {
        breadText = GetComponent<Text>();
        UpdateBread();
    }

    private void UpdateBread () {
        breadText.text = breads.ToString();
    }

    public void AddBread(int breadAmount) {
        breads += breadAmount;
        UpdateBread();
    }

    public void SpendBread(int breadAmount) {
        if (breads >= breadAmount) {
            breads -= breadAmount;
            UpdateBread();
        }
    }
}
