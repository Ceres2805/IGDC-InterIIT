using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd2 : MonoBehaviour
{
     public void Mainmenuu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-4); // Reload current scene
    }
     public void Quitts()
    {
        Application.Quit();
    }
}
