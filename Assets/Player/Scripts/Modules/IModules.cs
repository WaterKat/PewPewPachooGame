using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModules
{
    string TriggerInput { get; }
    void TriggerModule(string _input);
    void SetTriggerInput(string _input);
}
