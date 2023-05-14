using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCount : MonoBehaviour
{
    [SerializeField] ShowExit _showExit;
    [SerializeField] ParticleSystem _particleSystem;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletController>())
        {
            _showExit.CountSuccess();
            _particleSystem.Play();
            Destroy(gameObject, 1f);
        }
    }
}
