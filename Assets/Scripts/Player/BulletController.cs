using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float onScreenDelay = 3f;

    private void Start()
    {
        //���������� ��������� ������ ����� 3 �������
        Destroy(this.gameObject, onScreenDelay);
    }
}
