using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 5f)]
    float currSpeed = 0.6f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currSpeed);
    }

    public void SetMovementSpeed(float speed) {
        currSpeed = speed;
    }
}
