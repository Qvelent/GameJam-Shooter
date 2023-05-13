using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDisplay : MonoBehaviour
{
    [SerializeField] private Material[] _colorDisplay;
    [SerializeField] int index = 0;


    public void ChangeColor()
    {
        index++;
        if (_colorDisplay.Length == index)
        {
            index = 0;
        }
        GetComponent<Renderer>().material = _colorDisplay[index];
    }
}
