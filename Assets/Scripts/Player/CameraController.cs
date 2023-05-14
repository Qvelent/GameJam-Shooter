using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [Header("Стрельба")]
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private Collider _playerColider;
    [SerializeField] private AudioSource _shotSound;

    public Transform player;


    [Header("чувствительность мыши")]
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
        Cursor.lockState = CursorLockMode.Locked; //заблокировали курсор
    }

    public void CursorAnLock()
    {
        Cursor.lockState = CursorLockMode.None; //разблокировали курсор
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
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime; // значение инпут.гетахис дает от -1 до 1, а с помощью сенсивити мы умножаем это число и получаем другую скорость поворта. Тайм.делтьа тайм чисто для регулировки кадров и чтобы убрать разрыв кадров(или чет такое)
        mouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        xRotation -= mouseY; // убираем инверсию. Называем хротейшен так как чтобы изменить по оси У надо в самом юнити менять по осе Х

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // фиксация значения, то есть передаем переменную и максимальное значение камеры поворота 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //кватрион делает вектор, точнее в нашу переменную он присвоит хротейшен в Х 


        player.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Создает префаб пули, при нажатии левой кнопки мыши
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

            bulletRB.velocity = this.transform.forward * bulletSpeed; // Используем velocity, вместе AddForce, чтобы пули не тянуло гравитацией вниз
        }
    }
}