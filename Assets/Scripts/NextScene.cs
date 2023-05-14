using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(6);
         SceneManager.LoadScene("Scene_2");
    }

    public void StartCoroutine()
    {
        StartCoroutine(LoadScene());
    }
}
