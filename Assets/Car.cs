using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Rigidbody _rigibody;
    [SerializeField] private float force = 1f;
    [SerializeField] private float angleChangeSpeed = 3f;

    void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rigibody.AddForce(transform.forward * force, ForceMode.VelocityChange);
        _rigibody.AddTorque(transform.up * angleChangeSpeed, ForceMode.VelocityChange);
    }
}
