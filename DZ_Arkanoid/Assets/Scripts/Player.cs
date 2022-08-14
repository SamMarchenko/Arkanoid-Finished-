using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;
    [SerializeField] private float _slide = 1;
    public float Slide => _slide;
    public bool IsActive = true;
    public Action PressedEscape;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressedEscape?.Invoke();
        }
    }
}