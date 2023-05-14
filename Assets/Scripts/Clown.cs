using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;

    [SerializeField] private GameObject obj;


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;
        {
            gameObject.SetActive(false);
            audioSource1.Play();
            audioSource2.Stop();

            obj.SetActive(true);
            
        }
        
    }
}
