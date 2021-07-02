using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text text;

    private void Update()
    {
        text.text = "Health: " + playerHealth.health + " / " + playerHealth.maxHealth;
    }
}
