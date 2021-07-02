using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour
{
    public SurvivalCounter survivalCounter;

    public float currentTime = 0;

    public Text text;

    private void Awake()
    {
        if (FindObjectsOfType<HighScore>().Length > 1)
        {
            Destroy(transform.parent.gameObject);
            this.enabled = false;
        }
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    void Update()
    {
        if (survivalCounter == null)
        {
            survivalCounter = FindObjectOfType<SurvivalCounter>();
        }
        if (survivalCounter.timeElapsed > currentTime)
        {
            currentTime = survivalCounter.timeElapsed;
            text.text = "High Score : " + returnTimeInMinutes(currentTime);
        }
    }

    string returnTimeInMinutes(float inputSeconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(inputSeconds);
        return t.ToString(@"mm\:ss\:ff");
    }
}
