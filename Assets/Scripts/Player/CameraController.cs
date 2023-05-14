using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [Header("��������")]
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private Collider _playerColider;
    [SerializeField] private AudioSource _shotSound;

    public Transform player;


    [Header("���������������� ����")]
    public float sensivityMouse = 200f;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        CursorLock();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Look();
        RangeToUseItems();
    }


    private void Update()
    {
        Fire();
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked; //������������� ������
    }

    public void CursorAnLock()
    {
        Cursor.lockState = CursorLockMode.None; //�������������� ������
    }

    public GameObject RangeToUseItems()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }

    }


    public void Look()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime; // �������� �����.������� ���� �� -1 �� 1, � � ������� ��������� �� �������� ��� ����� � �������� ������ �������� �������. ����.������ ���� ����� ��� ����������� ������ � ����� ������ ������ ������(��� ��� �����)
        mouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        xRotation -= mouseY; // ������� ��������. �������� ��������� ��� ��� ����� �������� �� ��� � ���� � ����� ����� ������ �� ��� �

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // �������� ��������, �� ���� �������� ���������� � ������������ �������� ������ �������� 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //�������� ������ ������, ������ � ���� ���������� �� �������� ��������� � � 


        player.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// ������� ������ ����, ��� ������� ����� ������ ����
    /// </summary>
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform trans = this.transform;
            GameObject newBullet = Instantiate(_prefabBullet, trans.position, trans.rotation) as GameObject;
            Physics.IgnoreCollision(_playerColider, newBullet.GetComponent<Collider>());
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            _shotSound.pitch = Random.Range(0.8f, 1.2f);
            _shotSound.Play();

            bulletRB.velocity = this.transform.forward * bulletSpeed; // ���������� velocity, ������ AddForce, ����� ���� �� ������ ����������� ����
        }
    }
}