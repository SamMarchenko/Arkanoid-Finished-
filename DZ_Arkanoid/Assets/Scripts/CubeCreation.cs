using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CubeCreation : MonoBehaviour
{
    [SerializeField] private CubeView cubePrefab;
    [SerializeField] private int _numberCubes;
    public List<CubeView> Cubes = new List<CubeView>();
    private Random _random = new Random();
    
    void Start()
    {
        for (var i = 0; i < _numberCubes; i++)
        {
            Cubes.Add(CreateCube());
        }
    }
    

    private CubeView CreateCube()
    {
        var cube = Instantiate(cubePrefab);
        cube.transform.position = new Vector3(_random.Next(1,9),_random.Next(-4,4), _random.Next(-3,3) );
        cube.transform.Rotate(new Vector3(_random.Next(360),_random.Next(360),_random.Next(360)));
        return cube;
    }
}
