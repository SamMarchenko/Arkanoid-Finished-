using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float slide = 1;
    public bool _isActive = true;
    private void Update()
    {
        if (_isActive)
        {
            Moving(); 
        }
    }
    
    private void Moving()
    {
        if (gameObject.CompareTag("Player1"))
        {
            FirstPlayerMove();
        }
        if (gameObject.CompareTag("Player2"))
        {
            SecondPlayerMove();
        }
        
    }

    private void FirstPlayerMove()
    {
        //Rigidbody.Drag не должно быть равно 0
        if (Input.GetKey (KeyCode.A))
        {
            transform.Translate(Vector3.left*Time.deltaTime);
            _rigidbody.velocity = new Vector3(-slide,0,0);
        }
        if (Input.GetKey (KeyCode.D))
        {
            transform.Translate(Vector3.right*Time.deltaTime);
            _rigidbody.velocity = new Vector3(slide,0,0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up*Time.deltaTime);
            _rigidbody.velocity = new Vector3(0,slide,0);
        }
        if (Input.GetKey (KeyCode.S))
        {
            transform.Translate(Vector3.down*Time.deltaTime);
            _rigidbody.velocity = new Vector3(0,-slide,0);
        }
    }
    
    private void SecondPlayerMove()
    {
        //Rigidbody.Drag не должно быть равно 0
        if (Input.GetKey (KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left*Time.deltaTime);
            _rigidbody.velocity = new Vector3(slide,0,0);
        }
        if (Input.GetKey (KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right*Time.deltaTime);
            _rigidbody.velocity = new Vector3(-slide,0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up*Time.deltaTime);
            _rigidbody.velocity = new Vector3(0,slide,0);
        }
        if (Input.GetKey (KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down*Time.deltaTime);
            _rigidbody.velocity = new Vector3(0,-slide,0);
        }
    }
    
}
