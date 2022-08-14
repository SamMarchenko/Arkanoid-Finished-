using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    public Action<CubeView> BallCollision;
    public Action PressedSpace;
    public Action GateCollision;
    [SerializeField] private Vector3 _normal;
    [SerializeField] private Vector3 _result;
    [SerializeField] private Vector3 inDirection;
    [SerializeField] private float Acceleration;
    [SerializeField] private float MaxAcceleration;
    public bool IsActive;

    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {    //todo: по ТЗ нельзя движение физикой реализовывать
        //_rigidbody.AddForce(Vector3.forward, ForceMode.VelocityChange);
        inDirection = transform.forward + new Vector3(0.1f,0.1f,0);

    }

    private void Update()
    {
        if (IsActive)
        {
            transform.Translate(inDirection *Acceleration * Time.deltaTime);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            inDirection = transform.forward + new Vector3(0.1f,0.1f,0);
            PressedSpace?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gate"))
        {
            GateCollision?.Invoke();
            return;
        }
        ChangeBallDirection(collision);
        UpdateMoveSpeed();
        
        if (isCollisionWithCube(collision, out var cubeView))
        {
            BallCollision?.Invoke(cubeView);
        }
    }

    private void UpdateMoveSpeed()
    {
        if (Acceleration >= MaxAcceleration) return;
        Acceleration+= 0.05f;
    }

    private void ChangeBallDirection(Collision collision)
    {
        _normal = collision.contacts[0].normal;
        _result = Vector3.Reflect(inDirection, _normal);
        transform.rotation = Quaternion.Euler(_result);
        inDirection = _result;
        //todo: по ТЗ нельзя движение физикой реализовывать
        //_rigidbody.AddForce(_result*Acceleration, ForceMode.VelocityChange);
        
    }

    private bool isCollisionWithCube(Collision collision, out CubeView cubeView)
    {
        cubeView = collision.gameObject.GetComponent<CubeView>();
        return cubeView != null;
    }

    
}
