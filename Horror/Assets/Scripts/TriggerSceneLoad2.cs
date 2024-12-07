using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TriggerSceneLoad2 : MonoBehaviour
{
    // This will load the next scene after 5 seconds
    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger
        if (other.CompareTag("Player"))
        {
            // Start the coroutine to load the scene after a delay
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    // Coroutine to load the next scene after a 5-second delay
    IEnumerator LoadSceneAfterDelay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
    }
}

