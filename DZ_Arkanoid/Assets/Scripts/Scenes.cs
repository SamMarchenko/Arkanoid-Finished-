using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
   public void PlayLevel(int _sceneNumber)
   {
      SceneManager.LoadScene(_sceneNumber,LoadSceneMode.Single);
   }

   public void ExitGame()
   {
      Application.Quit();
      // имитация выхода в редакторе
      UnityEditor.EditorApplication.isPaused = true;
   }
}
