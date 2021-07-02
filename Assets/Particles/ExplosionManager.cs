using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private static ExplosionManager main;

    public GameObject particle;

    private void Awake()
    {
        main = this;
    }

    public static void ExplodeAtPoint(Vector3 point)
    {
        GameObject particles = Instantiate(main.particle,main.transform);
        particles.SetActive(true);
        particles.transform.position = point - Vector3.forward;
        Destroy(particles,5);
    }
}
