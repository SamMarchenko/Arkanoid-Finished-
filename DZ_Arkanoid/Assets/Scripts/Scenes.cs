using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour, IDisposable
{
   [SerializeField] private Animator _mainMenuAnimator;
   [SerializeField] private Button _startGameButton;
   [SerializeField] private Button _exitGameButton;

   private void Awake()
   {
      _startGameButton.onClick.AddListener(()=>PlayLevel(1));
      _exitGameButton.onClick.AddListener(ExitGame);
   }
   public void PlayLevel(int _sceneNumber)
   {
      _mainMenuAnimator.enabled = true;
      StartCoroutine(LoadGameSceneRoutine(_sceneNumber));
   }

   private IEnumerator LoadGameSceneRoutine(int _sceneNumber)
   {
     yield return new WaitForSeconds(1f);
     SceneManager.LoadScene(_sceneNumber,LoadSceneMode.Single);
   }

   public void ExitGame()
   {
      Application.Quit();
      // имитация выхода в редакторе
      UnityEditor.EditorApplication.isPaused = true;
   }

   public void Dispose()
   {
      _startGameButton.onClick.RemoveAllListeners();
      _exitGameButton.onClick.RemoveAllListeners();
   }
}
