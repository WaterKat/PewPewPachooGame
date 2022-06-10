using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Audio;

public class BoostModule : MonoBehaviour, IModules
{
    [SerializeField]
    private float boost = 100f;
    [SerializeField]
    private float BoostCooldown = 2f;
    private float lastBoosted = 0;

    [SerializeField]
    private Rigidbody2D parentRigidbody = null;

    private void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    [SerializeField]
    private string triggerInput = "A";
    public string TriggerInput
    {
        get
        {
            return triggerInput;
        }
    }

    public void SetTriggerInput(string _input)
    {
        triggerInput = _input;
    }

    [SerializeField]
    private GameObject DisplayObject;

    private void Update()
    {
        if ((Time.time - lastBoosted > BoostCooldown)&&(DisplayObject.activeSelf == false))
        {
            DisplayObject.SetActive(true);
        }
    }


    public void TriggerModule(string Input)
    {
        if (Input != TriggerInput) { return; }

        Debug.Log("tried boost");

        if (Time.time - lastBoosted > BoostCooldown)
        {
            lastBoosted = Time.time;

            if (parentRigidbody != null)
            {
                parentRigidbody.velocity += (Vector2)(transform.rotation * Vector2.left * boost);
                AudioManager.PlaySound("Player_Boosted");
            }

            DisplayObject.SetActive(false);
        }

    }
}
