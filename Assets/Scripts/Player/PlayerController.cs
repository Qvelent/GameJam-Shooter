using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform characterSize;


    [Header("Гравитация")]
    [SerializeField] private float verticalVelocity;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpForce = 5.0f;

    [Header("Стрельба")]
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float bulletSpeed = 100f;

    [Header("Скорость нашего чара")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float runSpeed = 3f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.Move(new Vector3(0f, 1f, 0));
    }

    private void Update()
    {
        Fire();
    }


    void FixedUpdate()
    {
        Move();
        
        PlayerReset();
    }

    
    /// <summary>
    /// Задает перемещение игрока
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
    /// Респавнит в определенной точке Игрока
    /// </summary>
    private void PlayerReset()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            controller.Move(new Vector3(0, 10f, 0));
        }
    }

    /// <summary>
    /// Создает префаб пули, при нажатии левой кнопки мыши
    /// </summary>
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform trans = this.transform;
            GameObject newBullet = Instantiate(_prefabBullet, trans.position + new Vector3(1, 0, 0), trans.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * bulletSpeed; // Используем velocity, вместе AddForce, чтобы пули не тянуло гравитацией вниз
        }
    }
}
