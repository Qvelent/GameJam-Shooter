using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaTrigger : MonoBehaviour
{
    [SerializeField] ShowExit _showExit;
    [SerializeField] private int _countColaMax = 6;
    [SerializeField] private int _countCola = 0;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cola")
        {
            _countCola++;
        }

        if (_countCola == _countColaMax)
        {
            _showExit.CountSuccess();
        }
    }
}
