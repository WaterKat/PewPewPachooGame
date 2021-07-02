using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;
    public GameObject display;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0;
                display.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                display.SetActive(false);
            }
        }
    }
}
