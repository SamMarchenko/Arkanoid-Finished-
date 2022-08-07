using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BallMoving _ballMoving;
        [SerializeField] private int _lifes = 3;
        [SerializeField] private PlayerMove _player1;
        [SerializeField] private PlayerMove _player2;
        [SerializeField] private CubeCreation _cubeCreation;
        private Vector3 _player1StartPos;
        private Vector3 _player2StartPos;
        private bool isWin;
        private void Start()
        {
            _ballMoving._isActive = false;
            _player1StartPos = _player1.transform.position;
            _player2StartPos = _player2.transform.position;
            _ballMoving.GateCollision += GateCollision;
            _ballMoving.PressedSpace += PressedSpace;
            _ballMoving.BallCollision += BallCollision;
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
                _ballMoving._isActive = true;
            }
        }

        private void Update()
        {
            if (_player1._isActive && !_ballMoving._isActive)
            {
                _ballMoving.transform.position = _player1.transform.position + Vector3.forward*2f;
            }
        }

        private void GateCollision()
        {
            if (_lifes > 1)
            {
                _lifes--;
                StartPositions();
                Debug.Log($"Minus heart. Hearts = {_lifes}");
            }
            else
            {
                _lifes = 0;
                EndGame();
               Debug.Log("Game Over");
            }
        }

        private void StartPositions()
        {
            _ballMoving._isActive = false;
            _player1.transform.position = _player1StartPos;
            _player2.transform.position = _player2StartPos;
            _ballMoving.transform.position = _player1StartPos + Vector3.forward*2f;
        }

        private void EndGame()
        {
            StartPositions();
            _player1._isActive = false;
            _player2._isActive = false;
        }
    }
}