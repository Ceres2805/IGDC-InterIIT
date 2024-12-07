using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd1 : MonoBehaviour
{
     public void Mainmenuu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2); // Reload current scene
    }
     public void Quitts()
    {
        Application.Quit();
    }
}
