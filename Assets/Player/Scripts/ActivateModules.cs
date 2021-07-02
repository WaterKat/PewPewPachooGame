using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActivateModules : MonoBehaviour
{
    [SerializeField]
    private IModules[] modules;

    [SerializeField]
    private string inputTriggerA = "Fire1";
    [SerializeField]
    private string inputTriggerB = "Fire2";
    /*
    [SerializeField]
    private string inputTriggerC = "Fire3";
    [SerializeField]
    private string inputTriggerD = "Fire4";
    */

    private void Start()
    {
        modules = GetComponentsInChildren<IModules>();
        Debug.Log("Modules Found!: " + modules.Length);
    }

    private float lastTriggeredA = 0;
    private float rateOfFireTriggerA = 0.125f;

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetButtonDown(inputTriggerA))
        {
            lastTriggeredA -= rateOfFireTriggerA;
        }
        if (Input.GetButton(inputTriggerA))
        {
            if (Time.time - lastTriggeredA > rateOfFireTriggerA)
            {
                lastTriggeredA = Time.time;
                foreach (IModules module in modules)
                {
                    module.TriggerModule("A");
                }
            }
        }
        if (Input.GetButtonDown(inputTriggerB))
        {
            foreach (IModules module in modules)
            {
                module.TriggerModule("B");
            }
        }
        /*
        if (Input.GetButtonDown(inputTriggerC))
        {
            foreach (IModules module in modules)
            {
                module.TriggerModule("C");
            }
        }
        if (Input.GetButtonDown(inputTriggerD))
        {
            foreach (IModules module in modules)
            {
                module.TriggerModule("D");
            }
        }
        */
    }
}
