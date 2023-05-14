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
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 6)
        {
            text.text = "Press E";
            if (Input.GetKeyDown(KeyCode.E))
            {
                buttonPress.Invoke();
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 6)
        {
            text.text = "";
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
