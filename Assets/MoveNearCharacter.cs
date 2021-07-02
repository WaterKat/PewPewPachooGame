using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNearCharacter : MonoBehaviour
{
    public GameObject target;
    public float maxDistance = 20f;

    private void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        if (Vector3.Distance(target.transform.position, transform.position) > maxDistance)
        {
            transform.position = target.transform.position + (Vector3)((Vector2)UnityEngine.Random.onUnitSphere).normalized * (maxDistance-1);
            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

    }
}
