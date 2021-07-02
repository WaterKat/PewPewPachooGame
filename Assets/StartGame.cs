﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
