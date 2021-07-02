using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopImage : MonoBehaviour
{
    public Transform target;
    public float size;

    private void Update()
    {
        Vector2 pos = new Vector2();
        pos.x = Mathf.Floor(target.position.x / size);
        pos.y = Mathf.Floor(target.position.y / size);

        transform.position = pos * size;
    }
}
