using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuUI; // Assign the Pause Menu UI GameObject in the Inspector

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f;         // Resume game time
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor for gameplay
        Cursor.visible = false;     // Hide the cursor
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f;         // Freeze game time
        Cursor.lockState = CursorLockMode.None;   // Unlock the cursor for UI interaction
        Cursor.visible = true;      // Show the cursor
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Ensure time resumes before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure time resumes before quitting
        Debug.Log("Quitting Game..."); // Debug message for testing in Editor
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1); // Quit the application
    }
}


