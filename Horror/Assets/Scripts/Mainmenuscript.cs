using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenuscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void Playbutton()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
   public void QuitButton()
   {
    Application.Quit();
   }

   public void Options()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+4);
   }
}
