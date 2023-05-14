using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    [SerializeField] private string sceneManager;

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(6);
         SceneManager.LoadScene(sceneManager);
    }

    public void StartCoroutine()
    {
        StartCoroutine(LoadScene());
    }
}
