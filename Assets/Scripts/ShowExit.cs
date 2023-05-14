using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExit : MonoBehaviour
{
    [SerializeField] int _countConditions = 0;
    [SerializeField] int _maxConditions = 3;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void CountSuccess()
    {
        _countConditions++;
        if (_countConditions == _maxConditions)
        {
            gameObject.SetActive(true);
        }
    }
}
