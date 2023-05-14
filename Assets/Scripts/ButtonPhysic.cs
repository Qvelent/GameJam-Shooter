using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonPhysic : MonoBehaviour
{
    [SerializeField] UnityEvent buttonPress;
    [SerializeField] TMP_Text text;
    [SerializeField] private Renderer[] _renderers;

  
    private void OnMouseOver()
    { 
            text.text = "Press E";
            if (Input.GetKeyDown(KeyCode.E))
            {
                buttonPress.Invoke();
            } 
    }

    public void SetEmissionMax(int index)
    {
        _renderers[index].material.SetColor("_EmissionColor", Color.clear);
    }
    public void SetEmissionMin(int index)
    {
        _renderers[index].material.SetColor("_EmissionColor", Color.white);
    }

    private void OnMouseExit()
    {
        text.text = "";
    }
}
