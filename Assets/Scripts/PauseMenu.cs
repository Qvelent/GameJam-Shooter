using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public bool _isPaused = false;
    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void CursorAnLock()
    {
        Cursor.lockState = CursorLockMode.None; 
    }
    public void PauseGame()
    {
        CursorAnLock();
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        CursorLock();
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }
}
