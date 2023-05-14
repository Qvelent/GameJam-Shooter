using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumkinHitCollision : MonoBehaviour
{
    [SerializeField] GameObject lights;
    [SerializeField] Light light;

    private void Start()
    {
        light = lights.GetComponent<Light>();
        light.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.GetComponent<BulletController>())
        {
            light.enabled = true;
        }
    }
}
