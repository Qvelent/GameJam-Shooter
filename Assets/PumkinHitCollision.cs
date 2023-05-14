using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumkinHitCollision : MonoBehaviour
{
    [SerializeField] GameObject[] lights;

    private void Start()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.GetComponent<BulletController>())
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(true);
            }
        }
    }
}
