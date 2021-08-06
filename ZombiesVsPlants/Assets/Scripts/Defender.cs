using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] int breadCost = 100;

    public void AddBread(int amount) {
        FindObjectOfType<BreadDisplay>().AddBread(amount);
    }

    public int GetBreadCost() {
        return breadCost;
    }

}
