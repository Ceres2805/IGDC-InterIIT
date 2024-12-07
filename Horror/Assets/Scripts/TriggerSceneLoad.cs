using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneLoad : MonoBehaviour
{
    // This will load the next scene in the build settings
    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger
        if (other.CompareTag("Player"))
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Reload current scene
    
        }
    }
}

