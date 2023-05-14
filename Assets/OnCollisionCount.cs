using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCount : MonoBehaviour
{
    [SerializeField] ShowExit _showExit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletController>())
        {
            _showExit.CountSuccess();
        }
    }
}
