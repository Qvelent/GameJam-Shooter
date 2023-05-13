using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform characterSize;


    [Header("����������")]
    [SerializeField] private float verticalVelocity;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpForce = 5.0f;

    
    [Header("�������� ������ ����")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float runSpeed = 3f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.Move(new Vector3(0f, 1f, 0));
    }


    void FixedUpdate()
    {
        Move();
        
        PlayerReset();
    }

    
    /// <summary>
    /// ������ ����������� ������
    /// </summary>
    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = 1f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(Vector3.ClampMagnitude(move.normalized, 2 * speed * Time.deltaTime));
    }


    /// <summary>
    /// ��������� � ������������ ����� ������
    /// </summary>
    private void PlayerReset()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            controller.Move(new Vector3(0, 10f, 0));
        }
    }
}
