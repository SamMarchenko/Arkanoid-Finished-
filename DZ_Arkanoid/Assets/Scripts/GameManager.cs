using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BallMoving _ballMoving;
        [SerializeField] private int _lifes = 3;
        [SerializeField] private Transform _player1StartPos;
        [SerializeField] private Transform _player2StartPos;

        private void Start()
        {
            _ballMoving.GateCollision += GateCollision;
        }

        private void GateCollision()
        {
            if (_lifes > 1)
            {
                _lifes--;
                _ballMoving._isActive = false;
                _ballMoving.transform.position = _player1StartPos.position + Vector3.forward*2f;
                Debug.Log($"Minus heart. Hearts = {_lifes}");
            }
            else
            {
                _lifes = 0;
               _ballMoving._isActive = false;
               _ballMoving.transform.position = new Vector3(100,100,100);
                Debug.Log("Game Over");
            }
        }
    }
}