using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] private float _speed = 1f;
    [SerializeField] float _friction = 1f;
    [SerializeField] float _jumpPower = 5f;
    [SerializeField] bool _grounded = false;
    [SerializeField] private bool _isWalking = false;
    private bool _isUse = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                _rigidbody.AddForce(0f, _jumpPower, 0f, ForceMode.VelocityChange);
            }
        }

        if (_rigidbody.velocity.x != 0)
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isUse = true;
            
        }
        else
        {
            _isUse = false;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.forward * vertical + transform.right * horizontal).normalized;

        _rigidbody.AddForce(move * _speed, ForceMode.VelocityChange);

        _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, -_rigidbody.velocity.z * _friction, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                _grounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }

    public bool IsUse()
    {
        return _isUse;
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
