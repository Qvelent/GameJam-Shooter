using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float onScreenDelay = 3f;

    private void Start()
    {
        //”ничтожаем созданный объект через 3 секунды
        Destroy(this.gameObject, onScreenDelay);
    }
}
