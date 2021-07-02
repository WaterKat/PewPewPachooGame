using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalCounter : MonoBehaviour
{
    public Text text;
    public float timeElapsed = 0f;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        text.text = "Time Survived : " + returnTimeInMinutes(timeElapsed);
    }

    string returnTimeInMinutes(float inputSeconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(inputSeconds);
        return t.ToString(@"mm\:ss\:ff");
    }
}
