using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallMoving _ballMoving;
        [SerializeField] private CubeCreation _cubeCreation;

        private void Start()
        {
            _ballMoving.BallCollision += BallCollision;
        }

        private void BallCollision(CubeView cubeView)
        {
           Debug.Log("Stolknulsya");
           _cubeCreation.Cubes.Remove(cubeView);
           cubeView.Destroy();
        }
    }
}