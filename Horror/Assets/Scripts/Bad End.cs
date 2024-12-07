using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
     public void Mainmen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-3); // Reload current scene
    }
     public void Quitt()
    {
        Application.Quit();
    }
}
