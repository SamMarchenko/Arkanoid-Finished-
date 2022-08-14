using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour, IDisposable
    {
        [SerializeField] private BallMoving _ballMoving;
        [SerializeField] private int _lifes = 3;
        [SerializeField] private Player _player1;
        [SerializeField] private Player _player2;
        [SerializeField] private CubeCreation _cubeCreation;
        [SerializeField] private GameObject _menuWindow;
        [SerializeField] private Text _player1Lifes;
        [SerializeField] private Text _player2Lifes;
        private Vector3 _player1StartPos;
        private Vector3 _player2StartPos;
        private bool isWin;
        private bool isMenuOpen;
        private bool isRaundStarted;
        private void Start()
        { 
            _menuWindow.SetActive(false);
            SetPlayersLifes();
            _ballMoving.IsActive = false;
            _player1StartPos = _player1.transform.position;
            _player2StartPos = _player2.transform.position;
            _ballMoving.GateCollision += GateCollision;
            _ballMoving.PressedSpace += PressedSpace;
            _ballMoving.BallCollision += BallCollision;
            _player1.PressedEscape += PressedEscape;
        }

        private void SetPlayersLifes()
        {
            _player1Lifes.text = _lifes.ToString();
            _player2Lifes.text = _lifes.ToString();
        }

        private void PressedEscape()
        {
            if (isMenuOpen) return;
            _menuWindow.SetActive(true);
            PauseGame(true);
        }

        public void OnContinueClick()
        {
            _menuWindow.SetActive(false);
            PauseGame(false);
        }

        public void OnReloadClick(int _sceneNumber)
        {
            SceneManager.LoadScene(_sceneNumber,LoadSceneMode.Single);
        }

        public void OnExitClick()
        {
            UnityEditor.EditorApplication.isPaused = true;
        }

        private void PauseGame(bool status)
        {
            if (isRaundStarted)
            {
                _ballMoving.IsActive = !status;
            }
            _player1.IsActive = !status;
            _player2.IsActive = !status;
        }
        private void BallCollision(CubeView cubeView)
        {
            if (_cubeCreation.Cubes.Count > 1)
            {
                Debug.Log("Stolknulsya");
                _cubeCreation.Cubes.Remove(cubeView);
                cubeView.Destroy();
            }
            else
            {
                Debug.Log("WIN!!!!");
                _cubeCreation.Cubes.Remove(cubeView);
                cubeView.Destroy();
                isWin = true;
                EndGame();
            }
        }

        private void PressedSpace()
        {
            
            
            if (_lifes > 0 && !isWin)
            {
                
                if (_menuWindow.activeSelf)
                {
                    return;
                }
                if (!isRaundStarted) isRaundStarted = true;
                _ballMoving.IsActive = true;
            }
        }

        private void Update()
        {
            if (_player1.IsActive && !_ballMoving.IsActive)
            {
                _ballMoving.transform.position = _player1.transform.position + Vector3.forward*2f;
            }
        }

        private void GateCollision()
        {
            if (_lifes > 1)
            {
                _lifes--;
                SetPlayersLifes();
                StartPositions();
                Debug.Log($"Minus heart. Hearts = {_lifes}");
            }
            else
            {
                _lifes = 0;
                SetPlayersLifes();
                EndGame();
               Debug.Log("Game Over");
            }
        }

        private void StartPositions()
        {
            _ballMoving.IsActive = false;
            _player1.transform.position = _player1StartPos;
            _player2.transform.position = _player2StartPos;
            _ballMoving.transform.position = _player1StartPos + Vector3.forward*2f;
        }

        private void EndGame()
        {
            StartPositions();
            isRaundStarted = false;
            _player1.IsActive = false;
            _player2.IsActive = false;
        }

        public void Dispose()
        {
            _ballMoving.GateCollision -= GateCollision;
            _ballMoving.PressedSpace -= PressedSpace;
            _ballMoving.BallCollision -= BallCollision;
            _player1.PressedEscape -= PressedEscape;
        }
    }
}