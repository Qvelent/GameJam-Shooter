using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private EnterEvent _action;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(_tag)) return;

        _action?.Invoke(other.gameObject);
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
    }
}