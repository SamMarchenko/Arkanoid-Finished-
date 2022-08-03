using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlocksCreation : MonoBehaviour
{
    public GameObject blockPrefab;
    [SerializeField] private int _numberBlocks;
    public GameObject[] Blocks;
    private Random _random = new Random();

    private void Awake()
    {
        Blocks = new GameObject[_numberBlocks];
    }

    void Start()
    {
        //todo: почему-то совпадают координаты
        for (var i = 0; i < Blocks.Length; i++)
        {
            Blocks[i] = CreateBlock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject CreateBlock()
    {
        var block = Instantiate(blockPrefab);
        block.transform.position = new Vector3(_random.Next(2,9),_random.Next(-3,4), _random.Next(-6,7) );
        block.transform.Rotate(new Vector3(_random.Next(360),_random.Next(360),_random.Next(360)));
        return block;
    }
}
