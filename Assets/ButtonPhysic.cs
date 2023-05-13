using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonPhysic : MonoBehaviour
{
    [SerializeField] UnityEvent buttonPress;
    [SerializeField] TMP_Text text;


    private void OnMouseOver()
    {
        text.text = "Press E";
        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonPress.Invoke();
        }
    }

    private void OnMouseExit()
    {
        text.text = "";
    }
}
